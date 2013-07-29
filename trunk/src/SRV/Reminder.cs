namespace THS.UMS.SRV
{
    using System;
    using System.Configuration;
    using System.Diagnostics;
    using System.ServiceProcess;
    using System.Threading;

    using THS.UMS.AO;

    public partial class Reminder : ServiceBase
    {
        #region Properties
        private ManualResetEvent ResetEvent { get; set; }
        private bool StopRequested { get; set; }
        private Thread WorkThread { get; set; }
        private int RunInterval { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Reminder"/> class.
        /// </summary>
        public Reminder()
        {
            InitializeComponent();
            
            RunInterval = Convert.ToInt32(ConfigurationManager.AppSettings["ReminderRunInterval"]);
        }
        #endregion

        #region Protected
        /// <summary>
        /// When implemented in a derived class, executes when a Start command is sent to the service by the Service Control Manager (SCM) or when the operating system starts (for a service that starts automatically). Specifies actions to take when the service starts.
        /// </summary>
        /// <param name="args">Data passed by the start command.</param>
        protected override void OnStart(string[] args)
        {
            if (RunInterval == 0) OnStop();

            WorkThread = new Thread(DoWork) { IsBackground = true };
            WorkThread.Start();
        }

        /// <summary>
        /// When implemented in a derived class, executes when a Stop command is sent to the service by the Service Control Manager (SCM). Specifies actions to take when a service stops running.
        /// </summary>
        protected override void OnStop()
        {
            StopRequested = true;
            if (ResetEvent == null) return;
            ResetEvent.Set();
            WorkThread.Join();
        }
        #endregion

        #region Private
        /// <summary>
        /// Does the work.
        /// </summary>
        private void DoWork()
        {
            ResetEvent = new ManualResetEvent(false);
            while (!StopRequested)
            {
                try
                {
                    var n = new Notices();
                    var notes = n.GetExpirationNotices();

                    if (notes != null)
                    {
                        foreach (var note in notes)
                        {
                            n.AddNotice(note);
                        }
                    }
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry(ex.Message, EventLogEntryType.Error);
                }
                ResetEvent.WaitOne(TimeSpan.FromMinutes(RunInterval), true);
            }
        }
        #endregion
    }
}
