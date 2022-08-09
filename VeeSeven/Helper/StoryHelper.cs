using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeeSeven.Models;
using EntityLib.ImactStoriesManagment;

namespace VeeSeven.Helper
{
    public static class StoryHelper
    {
        public static ImactStorieModel ToModel(this ImpactStory entity)
        {
            ImactStorieModel model = new ImactStorieModel();
            if (entity !=null)
            {
                model.Id = entity.Id;
                model.Name = entity.Name;
                model.Headline = entity.Headline;
                model.Discription = entity.Discription;
            }
            else
            {
                model = null;
            }
            return model;
        }

        public static List<ImactStorieModel> ToList( this List<ImpactStory> entites)
        {
            List<ImactStorieModel> stories = new List<ImactStorieModel>();

            foreach (var story in entites)
            {
                stories.Add(story.ToModel());
            }

            return stories;
        }

        public static ImpactStory ToEntity(this ImactStorieModel model)
        {
            ImpactStory entity = new ImpactStory();

            if (model != null)
            {
                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.Headline = model.Headline;
                entity.Discription = model.Discription;
            }

            return entity;
        }


    }
}
