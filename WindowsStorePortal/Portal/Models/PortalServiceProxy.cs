using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Portal.PortalService;

namespace Store.Portal.Models
{
    public class PortalServiceProxy
    {
        private readonly IPortalService _portalService;

        public PortalServiceProxy()
        {
            _portalService = new PortalServiceClient();
        }

        public IEnumerable<StoreApp> GetSpecialApps()
        {
            var list = _portalService.GetSpecialApps();

            return
                list.Select(
                    a =>
                        new StoreApp
                        {
                            Guid = a.Guid,
                            Name = a.Name,
                            Price = a.Price,
                            Version = a.LatestVersion?.ToString()
                        }
                    ).ToList();
        }

        public IEnumerable<StoreApp> GetMostPopularApps()
        {
            var list = _portalService.GetMostPopularApps();

            return
                list.Select(
                    a =>
                        new StoreApp
                        {
                            Guid = a.Guid,
                            Name = a.Name,
                            Price = a.Price,
                            Version = a.LatestVersion?.ToString()
                        })
                    .ToList();
        }

        public IEnumerable<StoreApp> GetChosenApps()
        {
            var list = _portalService.GetChosenApps();

            return
                list.Select(
                    a =>
                        new StoreApp
                        {
                            Guid = a.Guid,
                            Name = a.Name,
                            Price = a.Price,
                            Version = a.LatestVersion?.ToString()
                        })
                    .ToList();
        }

        public IEnumerable<StoreApp> GetNewApps()
        {
            var list = _portalService.GetNewApps();

            return
                list.Select(
                    a =>
                        new StoreApp
                        {
                            Guid = a.Guid,
                            Name = a.Name,
                            Price = a.Price,
                            Version = a.LatestVersion?.ToString()
                        })
                    .ToList();
        }

        public IEnumerable<StoreApp> GetSpecialGames()
        {
            var list = _portalService.GetSpecialGames();

            return
                list.Select(
                    a =>
                        new StoreApp
                        {
                            Guid = a.Guid,
                            Name = a.Name,
                            Price = a.Price,
                            Version = a.LatestVersion?.ToString()
                        }
                    ).ToList();
        }

        public byte[] GetApp256Icon(Guid appGuid)
        {
            return _portalService.GetAppIcon256(appGuid);
        }

        public byte[] GetApp128Icon(Guid appGuid)
        {
            return _portalService.GetAppIcon128(appGuid);
        }
    }
}