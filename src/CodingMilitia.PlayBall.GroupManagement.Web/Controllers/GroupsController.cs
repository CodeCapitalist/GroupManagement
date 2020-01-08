using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CodingMilitia.PlayBall.GroupManagement.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingMilitia.PlayBall.GroupManagement.Web.Controllers
{
    [Route("groups")]
    public class GroupsController : Controller
    {
        private static long currentGroupId = 1;
        private static List<GroupViewModel> groups = new List<GroupViewModel>
        {
            new GroupViewModel{ ID = 1, Name = "SampleGroup"}
        };

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View(groups);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Details(long id)
        {
            var group = groups.SingleOrDefault(g => g.ID == id);
            if (group == null)
            {
                return NotFound();
            }
            else
            {
                return View(group);
            }
        }

        [HttpPost]
        [Route("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, GroupViewModel model)
        {
            var group = groups.SingleOrDefault(g => g.ID == id);
            if (group == null)
            {
                return NotFound();
            }
            else
            {
                group.Name = model.Name;
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(GroupViewModel model)
        {
            model.ID = ++currentGroupId;
            groups.Add(model);
            return RedirectToAction("Index");
        }
    }
}
