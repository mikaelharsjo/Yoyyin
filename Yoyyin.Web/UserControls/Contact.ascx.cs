using System;
using System.Collections.Generic;
using Yoyyin.Data;
using Yoyyin.Domain;
using Yoyyin.Domain.Services;
using Yoyyin.Domain.Users;

namespace Yoyyin.Web.UserControls
{
    public partial class Contact : UserControlWithDependenciesInjected
    {
        public List<IUser> YoyyinOwners;
        const string UserIDMicke = "fc24985e-fe13-45e3-b9a9-a86347762379";
        const string UserIDAnders = "62bb6821-dc9a-4375-ae4b-a09cc255d08f";
        const string UserIDPeter = "db29e60a-2648-4f4f-a8d8-dfb3d7dba544";

        public IUserRepository UserRepository { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            YoyyinOwners = new List<IUser>();
            var guidMicke = new Guid(UserIDMicke);
            var guidAnders = new Guid(UserIDAnders);
            var guidPeter = new Guid(UserIDPeter);

            YoyyinOwners.Add(UserRepository.GetUser(guidAnders));
            YoyyinOwners.Add(UserRepository.GetUser(guidPeter));
            YoyyinOwners.Add(UserRepository.GetUser(guidMicke));

            DataBind();
            //usersControl.SrcUsers = YoyyinOwners;
            //usersControl.DataBind();
        }
    }
}