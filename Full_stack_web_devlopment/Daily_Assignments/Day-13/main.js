const tableBody = document.getElementById("table_body");


function renderTable(products) {
    if (!Array.isArray(products)) products = [products]; 
    tableBody.innerHTML = products.map(p => `<tr>
        <td>${p.id}</td>
        <td>${p.title}</td>
        <td>${p.category ? p.category : "-"}</td>
        <td>₹${p.price}</td>
        <td>${p.rating ? p.rating : "-"}</td>
    </tr>`).join("");
}

/* GET */
function getProducts() {
    fetch("https://dummyjson.com/products")
        .then(res => res.json())
        .then(data => {
            const first5 = data.products.slice(0, 5);
            renderTable(first5);
        });
}

/* POST */
function addProduct() {
    const title = document.getElementById("title").value || "New Product";
    const price = Number(document.getElementById("price").value) || 500;
    const category = document.getElementById("category").value || "General";
    const rating = Number(document.getElementById("rating").value)||5;
    fetch("https://dummyjson.com/products/add", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
            title,price,category,rating
        })
    })
    .then(res => res.json())
    .then(data => {
        renderTable(data); 
    });
}

/* PUT */
function updateProduct() {
  const id = document.getElementById("productId").value;
  if(!id) { alert("Enter Product ID"); return; }
  const title = document.getElementById("title").value;
  const price = document.getElementById("price").value;
  const category = document.getElementById("category").value;
  const rating = document.getElementById("rating").value;
  
    fetch(`https://dummyjson.com/products/${id}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
            title,price,category,rating
        })
    })
    .then(res => res.json())
    .then(data => {
        renderTable(data);
    });
}

/* PATCH */
function patchProduct() {
  const id = document.getElementById("productId").value;
  if(!id) { alert("Enter Product ID"); return; }
  const patchData = {};

  const title = document.getElementById("title").value;
  const price = document.getElementById("price").value;
  const category = document.getElementById("category").value;
  const rating = document.getElementById("rating").value;

  if(title) patchData.title = title;
  if(price) patchData.price = Number(price);
  if(category) patchData.category = category;
  if(rating) patchData.rating = Number(rating);

    if (Object.keys(patchData).length === 0)
        return alert("Enter at least one field to PATCH");
  
    fetch(`https://dummyjson.com/products/${id}`, {
        method: "PATCH",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(patchData)
    })
    .then(res => res.json())
    .then(data => {
        renderTable(data);
    });
}

/* DELETE */
function deleteProduct() {
  const id = document.getElementById("productId").value;
  if(!id) { alert("Enter Product ID"); return; }
    fetch(`https://dummyjson.com/products/${id}`, {
        method: "DELETE"
    })
    .then(res => res.json())
    .then(data => {
        tableBody.innerHTML = "";
        alert(`DELETE Success: ID: ${data.id}, Title: ${data.title}`);
    });
}
