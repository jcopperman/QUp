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
        Project GetFeatureByID(int featureId);
        void InsertFeaturet(Feature feature);
        void DeleteFeature(int featureId);
        bool UpdateFeature(Feature feature);
        bool Save();
    }
}
