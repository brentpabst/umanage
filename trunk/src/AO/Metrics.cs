namespace THS.UMS.AO
{
    using System.Collections.Generic;
    using System.Linq;
    using System;

    using THS.UMS.AD;
    using THS.UMS.DTO;

    public class Metrics
    {
        /// <summary>
        /// Gets the location metrics.
        /// </summary>
        /// <returns></returns>
        public List<MetricDTO> GetLocationMetrics()
        {
            var list = new List<MetricDTO>();

            try
            {
                foreach (var l in new Locations().GetActiveLocations())
                {
                    var u = new Users(AppSettings.GetValue("AdUser"), AppSettings.GetValue("AdUserPass"));
                    var stats = new MetricDTO
                                    {
                                        Location = l,
                                        TotalUserCount = u.GetTotalUserCount(l.Directory, l.DistinguishedPath),
                                        ExpiredAccountCount = u.GetExpiredAccountCount(l.Directory, l.DistinguishedPath),
                                        ExpiredPasswordCount =
                                            u.GetExpiredPasswordCount(l.Directory, l.DistinguishedPath),
                                        ExpiringAccountCount =
                                            u.GetUsersWithExpiringAccounts(l.Directory, l.DistinguishedPath).Count(),
                                        ExpiringPasswordCount =
                                            u.GetUsersWithExpiringPasswords(l.Directory, l.DistinguishedPath).Count()
                                    };
                    list.Add(stats);
                }
                return list.OrderBy(l => l.Location.LocationName).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
