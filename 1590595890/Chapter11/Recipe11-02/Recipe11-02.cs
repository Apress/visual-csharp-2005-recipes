using System.Security;

namespace Apress.VisualCSharpRecipes.Chapter11
{
    class Recipe11_02
    {
        // A method to turn on CAS and persist the change.
        public void CasOn()
        {
            // Turn on CAS checks.
            SecurityManager.SecurityEnabled = true;

            // Persist the configuration change.
            SecurityManager.SavePolicy();
        }

        // A method to turn off CAS and persist the change.
        public void CasOff() 
        {
            // Turn off CAS checks.
            SecurityManager.SecurityEnabled = false;
                    
            // Persist the configuration change.
            SecurityManager.SavePolicy();
        }
    }
}
