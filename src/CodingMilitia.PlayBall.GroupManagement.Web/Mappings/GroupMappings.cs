using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CodingMilitia.PlayBall.GroupManagement.Web.Models;

using CodingMilitia.PlayBall.GroupManagement.Business.Models;

namespace CodingMilitia.PlayBall.GroupManagement.Web.Mappings
{
    public static class GroupMappings
    {
        public static GroupViewModel ToViewModel(this Group model)
        {
            //return model != null ? new GroupViewModel { ID = model.Id, Name = model.Name } : null;
            return new GroupViewModel {ID = model.Id, Name = model.Name};
        }

        public static Group ToServiceModel(this GroupViewModel model)
        {
            //return model != null ? new Group { Id = model.ID, Name = model.Name } : null;
            return new Group { Id = model.ID, Name = model.Name };
        }

        public static IReadOnlyCollection<GroupViewModel> ToViewModel(this IReadOnlyCollection<Group> models)
        {
            if (models.Count == 0)
            {
                return Array.Empty<GroupViewModel>();
            }
            else
            {
                var groups = new GroupViewModel[models.Count];
                int i = 0;
                foreach (var model in models)
                {
                    groups[i++] = model.ToViewModel();
                }

                return new ReadOnlyCollection<GroupViewModel>(groups);
            }
        }
    }
}
