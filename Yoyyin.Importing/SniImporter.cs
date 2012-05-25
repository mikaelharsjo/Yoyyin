using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Yoyyin.Data;
using Yoyyin.Data.Core.Entities;
using Yoyyin.Data.Core.Repositories;
using Yoyyin.Data.EntityFramework.Repositories;
using Yoyyin.Model.Users.ValueObjects;
using SniHead = Yoyyin.Model.Users.ValueObjects.SniHead;
using SniItem = Yoyyin.Model.Users.ValueObjects.SniItem;

namespace Yoyyin.Importing
{
    public class SniImporter
    {
        private IRepository<SniHead> _headRepository;
        private IRepository<Data.SniItem> _itemRepository;

        public SniImporter()
        {
            _itemRepository = new EFRepository<Data.SniItem>(new YoyyinEntities1(ConfigurationManager.ConnectionStrings["YoyyinEntities1"].ToString()));
        }

        public IEnumerable<Sni> Import()
        {
            foreach(Data.SniItem sniItem in _itemRepository.FindAll())
            {
                yield return
                    new Sni
                        {
                            SniItem = new SniItem {SniNo = sniItem.SniNo.Trim(), Title = sniItem.Title},
                            SniHead = 
                                sniItem.SniHead != null
                                    ? new SniHead
                                          {SniHeadId = sniItem.SniHead.SniHeadID.Trim(), Title = sniItem.SniHead.Title}
                                    : new SniHead() { SniHeadId = sniItem.SniHeadID}
                        };
            }
        }
    }
}
