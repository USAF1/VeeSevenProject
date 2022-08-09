using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeeSeven.Models;
using VeeSeven.Helper;
using EntityLib.ImactStoriesManagment;

namespace VeeSeven.Controllers
{
    public class ImpactStoryController : Controller
    {
        public IActionResult Index()
        {
            List<ImactStorieModel> stories = ImpactStoryHandler.getStories().ToList();

            if (stories != null)
            {

                ViewData["Stories"] = stories;

                return View();
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult AddStory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStory(ImactStorieModel model)
        {
            ImpactStoryHandler.AddStory(model.ToEntity());
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateStory(int id)
        {
            ImactStorieModel model = ImpactStoryHandler.getStory(id).ToModel();
            if (model != null) 
            {
                return View(model);
            }

            return BadRequest();
            
        }

        [HttpPost]
        public IActionResult UpdateStory(ImactStorieModel model)
        {

            ImpactStoryHandler.UpdateStory(model.ToEntity());

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteStory(int id)
        {
            ImactStorieModel model = ImpactStoryHandler.getStory(id).ToModel();

            if (model != null)
            {
                return View(model);
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult DeleteStory(ImactStorieModel model)
        {
            ImactStorieModel Story = ImpactStoryHandler.getStory(model.Id).ToModel();

            ImpactStoryHandler.DeleteStory(Story.ToEntity());

            return RedirectToAction("Index");
        }
    }
}
