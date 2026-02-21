const policiesData = [
  { id: 1, name: "Health Plus", type: "Health", premium: 12000, duration: 1, status: "Active" },
  { id: 2, name: "Life Secure", type: "Life", premium: 9000, duration: 10, status: "Inactive" },
  { id: 3, name: "Car Protect", type: "Vehicle", premium: 7000, duration: 1, status: "Active" },
  { id: 4, name: "Family Health", type: "Health", premium: 15000, duration: 2, status: "Active" }
];

let policies= [];

function fetch_policies_api() {
    return new Promise((resolve,reject) => {
        setTimeout(() =>{
            let success = true;
            if (success){
                resolve(policiesData);
            }
            else{
                reject("Failed");
            }
        },1000);
    });
}

async function fetch_policies(){
try {
    policies = await fetch_policies_api();
    displaypolicies(policies);
}
catch(error){
    console.log(error);
}
}
fetch_policies();

function displaypolicies(policies){
  const policies_display = document.getElementById("container");
  policies_display.innerHTML = "";

  policies.forEach(policy => {
    const card = document.createElement("div");
    card.className = "policy-card";
    card.innerHTML = `
      <h3>${policy.name}</h3>
      <p>Policy Type: ${policy.type}</p>
      <p>Premium: ${policy.premium}</p>
      <p>Duration: ${policy.duration}</p>
      <p>Status: ${policy.status}</p>
      <button onclick="approvePolicy(${policy.id}, alert)">Approve</button>
      <button onclick="purchasePolicy(${policy.id}, alert)">Purchase</button>
    `;

    policies_display.appendChild(card);
  });
}

function filterPolicies(type){
    let filteredPolicy;
    if (type == "All"){
        filteredPolicy = policies;
    }
    else{
        filteredPolicy = policies.filter(policy => policy.type === type);
    }
displaypolicies(filteredPolicy);
}

function activepolicies(status){
    const total = policies.filter(policy => policy.status === status)
    .reduce((sum,policy) => sum + policy.premium,0);
    alert("Total Premium of all active policies: " + total);
}

function premium_policies_discount() {
    const discounted_policies = policies.map(policy => {
        if (policy.premium > 10000) {
            return {
                ...policy,
                premium: policy.premium * 0.9  
            };
        }
        return policy;
    });

    displaypolicies(discounted_policies);
}
function approvePolicy(policyId, callback) {
    console.log("Policy approval in progress...");

    setTimeout(() => {
        const approved = true;

        if (approved) {
            callback(`Policy ${policyId} approved successfully ✅`);
        } else {
            callback(`Policy ${policyId} approval failed ❌`);
        }
    }, 2000);
}

function purchasePolicy(policyId) {
    return new Promise((resolve, reject) => {
        console.log("Processing policy purchase...");
        setTimeout(() => {
            const policy = policies.find(p => p.id === policyId);
            if (!policy) {
                reject("Invalid Policy ID ❌");
            } else {
                resolve(`Policy "${policy.name}" purchased successfully ✅`);
            }
        }, 2000);
    });
}

purchasePolicy(2)
    .then(successMessage => {
        console.log(successMessage);
    })
    .catch(errorMessage => {
        console.error(errorMessage);
    });
