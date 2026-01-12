/* Task - 1
document.getElementById("pagetitle").textContent = "Customer Insurance Overview";
*/
/* Task-2
const list_items = document.getElementsByTagName("li");
for (let li of list_items) {
    li.style.border = "1px solid #000";
}
console.log("Total items = " ,list_items.length);
*/ 
/*Task-3
const policies = document.getElementsByClassName("policy");
for (let policy of policies) {
  policy.classList.add("highlight");
  policy.style.color = "blue";
}
  */
/*Task-4 
const firstCustomer = document.querySelector(".customer");
console.log("First customer: ", firstCustomer);

const allCustomers = document.querySelectorAll(".customer");
console.log("All customers: ", allCustomers);

const lastCustomer = allCustomers[allCustomers.length - 1];
lastCustomer.classList.add("active");
*/
/*Task - 5 
console.log("Number of forms:", document.forms.length);
console.log("Number of images:", document.images.length);

for (let link of document.links) {
  link.textContent = "More Info";
}
  */
 /*Task-6
 const newcus = document.createElement("li");
 newcus.className = "customer";
 newcus.textContent = "srihith - house";
 document.getElementById("cuslist").appendChild(newcus);
 */

 /*Task-7
 const ans = document.querySelectorAll("input[type = 'text']");
 console.log(ans);
 for (let input of  ans){
    input.style.background = "yellow";
    input.placeholder = "enter fullname"
 }
    */
/*Task-8 
const prioritycustomers = 
    document.querySelectorAll(".customer.active");
console.log(prioritycustomers);
prioritycustomers.forEach(customer => {
  customer.style.color = "green";
  customer.textContent += "(priority customer);"
})
*/
/* Task -9
const descendantLis = document.querySelectorAll("#cuslist li");
const childLis = document.querySelectorAll("#cuslist > li");

console.log("Descendant li count:", descendantLis.length);
console.log("Child li count:", childLis.length);
*/
/*Task-10

const customers = document.querySelectorAll("#cuslist li");
customers.forEach((customer,index) => {
  if ((index+1)%2 == 0){
    customer.style.background = "lightgray";
  }
  else {
    customer.style.background = "lightblue";
  }
});

*/
/* Task - 11 
const enquiryForm = document.forms["enquiryForm"];
for(let i of enquiryForm.elements){
      console.log(element.name);
}
enquiryForm.querySelector("button").disabled = true;

*/
/* Task -12 
const a = document.getElementsByClassName("policy");
const b = document.querySelectorAll(".policy");
const new_p = document.createElement("p");
new_p.className="policy";
new_p.textContent = "travel";
document.body.appendChild(new_p);
console.log(a.length);
console.log(b.length);
* /
/* Task -13  
const customers = document.querySelectorAll(".customer");

customers.forEach(customer => {
  const text = customer.textContent.toLowerCase();
  if (text.includes("life")) {
    customer.style.backgroundColor = "lightgreen";
  }

  if (text.includes("vehicle")) {
    customer.style.display = "none";
  }
});
*/
/* Task -14 
const customers = document.querySelectorAll(".customer");
customers.forEach(customer => {
  customer.addEventListener("click", function () {
    const parentUl = this.closest("ul");
    parentUl.style.border = "3px solid red";
  });
});
*/

/* Task -15
const remainingPolicies =
  document.querySelectorAll("p.policy:not(:first-child)");

remainingPolicies.forEach(policy => {
  policy.style.fontStyle = "italic";
  policy.textContent = "✔ " + policy.textContent;
});
*/ 