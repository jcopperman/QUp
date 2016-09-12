using QUp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUp.DataModel.DAL
{
    public interface IFeatureRepository
    {
        IEnumerable<Feature> GetFeatures();
        Feature GetFeatureById(int featureId);
        void InsertFeature(Feature feature);
        void DeleteFeature(int featureId);
        bool UpdateFeature(Feature feature);
        bool Save();
    }
}
