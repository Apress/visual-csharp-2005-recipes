using System;
using System.Data;
using System.Runtime.Remoting;

namespace Apress.VisualCSharpRecipes.Chapter03
{
    class Recipe03_03
    {
        // A method to wrap a Dataset.
        public ObjectHandle WrapDataSet(DataSet ds) 
        {
            // Wrap the DataSet.
            ObjectHandle objHandle = new ObjectHandle(ds);

            // Return the wrapped DataSet.
            return objHandle;
        }

        // A method to unwrap a DataSet.
        public DataSet UnwrapDataSet(ObjectHandle handle)
        {
            // Unwrap the DataSet.
            DataSet ds = (System.Data.DataSet)handle.Unwrap();

            // Return the wrapped DataSet.
            return ds;
        }
    }
}