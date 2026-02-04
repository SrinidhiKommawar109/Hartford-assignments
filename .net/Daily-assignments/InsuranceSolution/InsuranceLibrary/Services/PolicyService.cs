using InsuranceLibrary.Models;
using System.Collections.Generic;

namespace InsuranceLibrary.Services
{
    public class PolicyService
    {
        private List<InsurancePolicy> policies = new List<InsurancePolicy>();

        public bool AddPolicy(InsurancePolicy policy)
        {
            foreach (var p in policies)
                if (p.PolicyId == policy.PolicyId)
                    return false;

            policies.Add(policy);
            return true;
        }

        public List<InsurancePolicy> GetAllPolicies()
        {
            return policies;
        }

        public InsurancePolicy GetPolicyById(int id)
        {
            foreach (var p in policies)
                if (p.PolicyId == id)
                    return p;

            return null;
        }

        public bool UpdatePolicy(int id, decimal premium, int term)
        {
            var p = GetPolicyById(id);
            if (p == null) return false;

            p.PremiumAmount = premium;
            p.PolicyTerm = term;
            return true;
        }

        public bool DeletePolicy(int id)
        {
            var p = GetPolicyById(id);
            if (p == null) return false;

            policies.Remove(p);
            return true;
        }
    }
}
