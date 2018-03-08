using NetMud.Authentication;
using NetMud.Data.EntityBackingData;
using NetMud.DataStructure.Base.Usage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace NetMud.Models.Admin
{
    public class ManageSlackUserViewModel : PagedDataModel<SlackUser>, BaseViewModel
    {
        public ApplicationUser authedUser { get; set; }

        public ManageSlackUserViewModel(IEnumerable<SlackUser> items)
            : base(items)
        {
            CurrentPageNumber = 1;
            ItemsPerPage = 20;
        }

        internal override Func<SlackUser, bool> SearchFilter
        {
            get
            {
                return item => item.Name.ToLower().Contains(SearchTerms.ToLower());
            }
        }
    }

    public class AddEditSlackUserViewModel : BaseViewModel
    {
        public ApplicationUser authedUser { get; set; }

        public AddEditSlackUserViewModel()
        {
        }

        [StringLength(100, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Display(Name = "Link")]
        public string[] Links { get; set; }

        public ISlackUser DataObject { get; set; }
    }
}