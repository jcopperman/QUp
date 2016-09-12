using QUp.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUp.DataModel.DAL
{
    public class FeatureRepository : IFeatureRepository
    {
        IQUpContext context;

        public FeatureRepository(IQUpContext _context)
        {
            context = _context;
        }

        public IEnumerable<Feature> GetFeatures()
        {
            return context.Features.ToList();
        }

        public Feature GetFeatureById(int feature)
        {
            return context.Features.Find(feature);
        }

        public void InsertFeature(Feature feature)
        {
            context.Features.Add(feature);

            Save();
        }

        public bool Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

            return true;
        }


        public bool FeatureExists(int id)
        {
            return context.Projects.Count(e => e.Id == id) > 0;
        }

        public bool UpdateFeature(Feature _feature)
        {
            Feature feature = GetFeatureById(_feature.Id);
            feature = _feature;

            var result = Save();

            return result;
        }

        public void DeleteFeature(int featureId)
        {
            Feature feature = context.Features.Find(featureId);
            context.Features.Remove(feature);
        }
    }
}
