using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using SoundInTheory.DynamicImage.Fluent;
using Yoyyin.Data;
using Yoyyin.Data.Core.Repositories;
using Yoyyin.Data.EntityFramework.Repositories;

namespace Yoyyin.Importing
{
    public class UserImageCreater
    {
        private IUserRepository _repository;

        public UserImageCreater()
        {
            _repository =
                new EFUserRepository(
                    new YoyyinEntities1(ConfigurationManager.ConnectionStrings["YoyyinEntities1"].ToString()));
        }

        public void CreateImages()
        {
            _repository
                .Find(u => u.Image != null)
                .ToList()
                .ForEach(user =>
                         new CompositionBuilder()
                             .WithLayer(LayerBuilder.Image.SourceBytes(user.Image)
                                            .WithFilter(FilterBuilder.Resize.ToWidth(170)))
                             .SaveTo("C:\\Users\\miha.STAFF\\Yoyyin\\Yoyyin.Mvc\\Content\\Upload\\Images\\" +
                                     user.UserId +
                                     ".jpg"));
        }
    }
}
