using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PPI.UMS.DAL;
using PPI.UMS.DTO;

namespace PPI.UMS.BLL
{
    /// <summary>
    /// Provides the interface for interacting with timeline messages
    /// </summary>
    [System.ComponentModel.DataObject()]
    public class Messages
    {
        #region Public

        /// <summary>
        /// Gets a collection of all timeline messages
        /// </summary>
        /// <returns>a generic List collection</returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public List<Message> GetAllMessages()
        {
            try
            {
                using (uManageEntities context = new uManageEntities())
                {
                    List<Message> msgs = new List<Message>();
                    foreach (TimelineMessage msg in context.TimelineMessages.Where(m => m.IsSysMsg == false).OrderByDescending(m => m.CreatedOn))
                    {
                        msgs.Add(BuildMessageFromEntity(msg));
                    }
                    return msgs;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Gets a collection of 15 timeline messages
        /// </summary>
        /// <returns>a generic List collection</returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public List<Message> GetTopMessages()
        {
            try
            {
                using (uManageEntities context = new uManageEntities())
                {
                    List<Message> msgs = new List<Message>();

                    var contextMsgs = context.TimelineMessages
                        .Where(m => m.IsSysMsg == false)
                        .OrderByDescending(m => m.CreatedOn)
                        .Take(15);

                    foreach (TimelineMessage msg in contextMsgs)
                    {
                        msgs.Add(BuildMessageFromEntity(msg));
                    }
                    return msgs;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Gets a collection of timeline messages
        /// </summary>
        /// <param name="count">The number of messages to get</param>
        /// <returns>a generic List collection</returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public List<Message> GetTopMessages(int count)
        {
            try
            {
                using (uManageEntities context = new uManageEntities())
                {
                    List<Message> msgs = new List<Message>();

                    var contextMsgs = context.TimelineMessages
                        .Where(m => m.IsSysMsg == false)
                        .OrderByDescending(m => m.CreatedOn)
                        .Take(count);

                    foreach (TimelineMessage msg in contextMsgs)
                    {
                        msgs.Add(BuildMessageFromEntity(msg));
                    }
                    return msgs;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Gets a collection of all system timeline messages
        /// </summary>
        /// <returns>a generic List collection</returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public List<Message> GetAllSystemMessages()
        {
            try
            {
                using (uManageEntities context = new uManageEntities())
                {
                    List<Message> msgs = new List<Message>();
                    foreach (TimelineMessage msg in context.TimelineMessages.Where(m => m.IsSysMsg == true).OrderByDescending(m => m.CreatedOn))
                    {
                        msgs.Add(BuildMessageFromEntity(msg));
                    }
                    return msgs;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Gets a collection of 15 system timeline messages
        /// </summary>
        /// <returns>a generic List collection</returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public List<Message> GetTopSystemMessages()
        {
            try
            {
                using (uManageEntities context = new uManageEntities())
                {
                    List<Message> msgs = new List<Message>();

                    var contextMsgs = context.TimelineMessages
                        .Where(m => m.IsSysMsg == true)
                        .OrderByDescending(m => m.CreatedOn)
                        .Take(15);

                    foreach (TimelineMessage msg in contextMsgs)
                    {
                        msgs.Add(BuildMessageFromEntity(msg));
                    }
                    return msgs;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Gets a collection of system timeline messages
        /// </summary>
        /// <param name="count">The number of messages to get</param>
        /// <returns>a generic List collection</returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public List<Message> GetTopSystemMessages(int count)
        {
            try
            {
                using (uManageEntities context = new uManageEntities())
                {
                    List<Message> msgs = new List<Message>();

                    var contextMsgs = context.TimelineMessages
                        .Where(m => m.IsSysMsg == true)
                        .OrderByDescending(m => m.CreatedOn)
                        .Take(count);

                    foreach (TimelineMessage msg in contextMsgs)
                    {
                        msgs.Add(BuildMessageFromEntity(msg));
                    }
                    return msgs;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Persists a timeline message to the data store
        /// </summary>
        /// <param name="title">The title of the message to add</param>
        /// <param name="description">The content or description of the message to add</param>
        /// <param name="category">The category of the message to add</param>
        /// <param name="isSysMessage">Specifies if the message is related to system configuration changes</param>
        /// <returns>The number of rows affected</returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, false)]
        public int AddMessage(string title, string description, string category, bool isSysMessage)
        {
            try
            {
                using (uManageEntities context = new uManageEntities())
                {
                    TimelineMessage msg = new TimelineMessage();

                    msg.MessageID = Guid.NewGuid();
                    msg.Title = title;
                    msg.Description = description;
                    msg.CreatedBy = HttpContext.Current.User.Identity.Name;
                    msg.CreatedOn = DateTime.UtcNow;
                    msg.Category = category;
                    msg.IsSysMsg = isSysMessage;

                    context.TimelineMessages.AddObject(msg);
                    return context.SaveChanges();
                }
            }
            catch
            {
                return 0;
            }
        }

        #endregion

        #region Private

        /// <summary>
        /// Generates a Message DTO object based on the data store
        /// </summary>
        /// <param name="msg">The ums_Message object to convert</param>
        /// <returns>A Message DTO object</returns>
        private Message BuildMessageFromEntity(TimelineMessage msg)
        {
            Message newMsg = new Message();

            newMsg.ID = msg.MessageID;
            newMsg.Title = msg.Title;
            newMsg.Description = msg.Description;
            newMsg.Category = msg.Category;
            newMsg.CreatedBy = msg.CreatedBy;
            newMsg.CreatedOn = msg.CreatedOn;
            newMsg.IsSysMsg = msg.IsSysMsg;

            return newMsg;
        }

        #endregion
    }
}
