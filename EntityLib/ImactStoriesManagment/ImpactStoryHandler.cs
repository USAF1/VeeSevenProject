using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLib.ImactStoriesManagment
{
    public class ImpactStoryHandler
    {
        public static List<ImpactStory> getStories()
        {
            using (ApplicationDB context =new ApplicationDB())
            {
                return context.ImpactStoies.ToList();
            }
        }

        public static ImpactStory getStory(int id)
        {
            using (ApplicationDB context = new ApplicationDB())
            {
                return (from Story in context.ImpactStoies where Story.Id == id select Story).FirstOrDefault();
            }
        }

        public static void AddStory(ImpactStory entity)
        {
            using (ApplicationDB context = new ApplicationDB())
            {
                context.Add(entity);
                context.SaveChanges();
            }
        }

        public static void UpdateStory(ImpactStory entity)
        {
            using (ApplicationDB context = new ApplicationDB())
            {
                context.Update(entity);
                context.SaveChanges();
            }
        }


        public static void DeleteStory(ImpactStory entity)
        {
            using (ApplicationDB context = new ApplicationDB())
            {
                context.Remove(entity);
                context.SaveChanges();
            }
        }
    }
}
