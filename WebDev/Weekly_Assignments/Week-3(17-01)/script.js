let accounts = [];
let transactions = {};
let currentAccountId = null;

const accountsGrid = document.getElementById("accountsGrid");
const loader = document.getElementById("loader");
const errorMsg = document.getElementById("errorMessage");
const searchInput = document.getElementById("searchInput");
const branchFilter = document.getElementById("branchFilter");
const sortBtn = document.getElementById("sortBtn");
const totalBalanceDisplay = document.getElementById("totalBalanceDisplay");
const createAccountForm = document.getElementById("createAccountForm");

const transactionModal = document.getElementById("transactionModal");
const historyModal = document.getElementById("historyModal");
const closeModal = document.querySelector(".close-modal");
const closeHistoryModal = document.querySelector(".close-modal-history");

const modalAccountName = document.getElementById("modalAccountName");
const transactionAmount = document.getElementById("transactionAmount");
const depositBtn = document.getElementById("depositBtn");
const withdrawBtn = document.getElementById("withdrawBtn");

/* ---------------- INIT ---------------- */

async function init() {
    loadFromLocalStorage();

    if (accounts.length === 0) {
        await fetchAccounts();
    } else {
        renderAccounts(accounts);
        populateBranchFilter();
        updateTotalBalance();
    }
}

/* ---------------- FETCH ACCOUNTS ---------------- */

async function fetchAccounts() {
    showLoader(true);
    try {
        const response = await fetch("https://jsonplaceholder.typicode.com/users");
        if (!response.ok) throw new Error("Fetch failed");

        const data = await response.json();

        accounts = data.map(user => ({
            id: user.id,
            name: user.name,
            email: user.email,
            branch: user.address.city,
            balance: Math.floor(Math.random() * 40001) + 10000
        }));

        saveToLocalStorage();
        renderAccounts(accounts);
        populateBranchFilter();
        updateTotalBalance();
    } catch (error) {
        showError("Error loading accounts. Please check your internet connection.");
    } finally {
        showLoader(false);
    }
}

/* ---------------- RENDER ACCOUNTS ---------------- */

function renderAccounts(data) {
    accountsGrid.innerHTML = "";

    if (data.length === 0) {
        accountsGrid.innerHTML = "<p>No accounts found.</p>";
        return;
    }

    data.forEach(acc => {
        const card = document.createElement("div");
        card.className = `account-card ${acc.balance < 5000 ? "low-balance" : ""}`;

        card.innerHTML = `
            <div class="account-header">
                <h3>${acc.name}</h3>
                <span class="account-id">ID: ${acc.id}</span>
            </div>
            <p><strong>Email:</strong> ${acc.email}</p>
            <p><strong>Branch:</strong> ${acc.branch}</p>
            <p><strong>Balance:</strong> ₹${acc.balance}</p>
            ${acc.balance < 5000 ? "<p style='color:red'>⚠️ Low Balance</p>" : ""}
            <div class="account-actions">
                <button class="btn btn-outline" onclick="openTransactionModal(${acc.id})">Transact</button>
                <button class="btn btn-outline" onclick="viewHistory(${acc.id})">History</button>
                <button class="btn btn-outline" onclick="deleteAccount(${acc.id})">Delete</button>
            </div>
        `;
        accountsGrid.appendChild(card);
    });
}

/* ---------------- SEARCH & FILTER ---------------- */

function filterAccounts() {
    const searchTerm = searchInput.value.toLowerCase();
    const branchValue = branchFilter.value;

    const filtered = accounts.filter(acc =>
        acc.name.toLowerCase().includes(searchTerm) &&
        (branchValue === "" || acc.branch === branchValue)
    );

    renderAccounts(filtered);
    updateTotalBalance(filtered);
}

searchInput.addEventListener("input", filterAccounts);
branchFilter.addEventListener("change", filterAccounts);

/* ---------------- SORT ---------------- */

sortBtn.addEventListener("click", () => {
    accounts.sort((a, b) => b.balance - a.balance);
    renderAccounts(accounts);
});

/* ---------------- BRANCH FILTER ---------------- */

function populateBranchFilter() {
    const branches = [...new Set(accounts.map(acc => acc.branch))];
    branchFilter.innerHTML = '<option value="">All Branches</option>';

    branches.forEach(branch => {
        const option = document.createElement("option");
        option.value = branch;
        option.textContent = branch;
        branchFilter.appendChild(option);
    });
}

/* ---------------- TOTAL BALANCE ---------------- */

function updateTotalBalance(list = accounts) {
    const total = list.reduce((sum, acc) => sum + acc.balance, 0);
    totalBalanceDisplay.innerText = `₹ ${total.toLocaleString()}`;
}

/* ---------------- CREATE ACCOUNT ---------------- */

createAccountForm.addEventListener("submit", e => {
    e.preventDefault();

    const newAccount = {
        id: Date.now(),
        name: newName.value,
        email: newEmail.value,
        branch: newBranch.value,
        balance: 10000
    };

    accounts.push(newAccount);
    saveToLocalStorage();
    createAccountForm.reset();
    renderAccounts(accounts);
    populateBranchFilter();
    updateTotalBalance();

    alert("Account Created Successfully!");
});

/* ---------------- DELETE ACCOUNT ---------------- */

window.deleteAccount = function (id) {
    if (!confirm("Are you sure you want to delete this account?")) return;

    accounts = accounts.filter(acc => acc.id !== id);
    delete transactions[id];
    saveToLocalStorage();
    renderAccounts(accounts);
    updateTotalBalance();
};

/* ---------------- TRANSACTIONS ---------------- */

window.openTransactionModal = function (id) {
    currentAccountId = id;
    const acc = accounts.find(a => a.id === id);
    modalAccountName.innerText = `Account: ${acc.name} (₹${acc.balance})`;
    transactionAmount.value = "";
    transactionModal.classList.remove("hidden");
};

closeModal.addEventListener("click", () => {
    transactionModal.classList.add("hidden");
});

depositBtn.addEventListener("click", () => handleTransaction("deposit"));
withdrawBtn.addEventListener("click", () => handleTransaction("withdraw"));

function handleTransaction(type) {
    const amount = Number(transactionAmount.value);
    if (!amount || amount <= 0) return alert("Enter valid amount");

    const acc = accounts.find(a => a.id === currentAccountId);

    if (type === "withdraw") {
        if (acc.balance < amount) return alert("Insufficient Balance");
        acc.balance -= amount;

        if (acc.balance < 5000) {
            acc.balance -= 200;
            alert("Low balance penalty ₹200 applied");
        }
    } else {
        acc.balance += amount;
    }

    addTransactionHistory(acc.id, type, amount, acc.balance);
    saveToLocalStorage();
    renderAccounts(accounts);
    updateTotalBalance();
    transactionModal.classList.add("hidden");
}

/* ---------------- HISTORY ---------------- */

function addTransactionHistory(id, type, amount, balance) {
    if (!transactions[id]) transactions[id] = [];
    transactions[id].unshift({
        date: new Date().toLocaleString(),
        type,
        amount,
        balance
    });
}

window.viewHistory = function (id) {
    const list = document.getElementById("transactionList");
    list.innerHTML = "";

    const history = transactions[id] || [];
    if (history.length === 0) {
        list.innerHTML = "<li>No transactions found.</li>";
        historyModal.classList.remove("hidden");
        return;
    }

    history.forEach(t => {
        const li = document.createElement("li");
        li.innerHTML = `
            <div class="history-type ${t.type}">${t.type.toUpperCase()} ₹${t.amount}</div>
            <div>Bal: ₹${t.balance}<br>${t.date}</div>
        `;
        list.appendChild(li);
    });

    historyModal.classList.remove("hidden");
};

closeHistoryModal.addEventListener("click", () => {
    historyModal.classList.add("hidden");
});

/* ---------------- UTILITIES ---------------- */

function showLoader(show) {
    loader.classList.toggle("hidden", !show);
}

function showError(msg) {
    errorMsg.innerText = msg;
    errorMsg.classList.remove("hidden");
    setTimeout(() => errorMsg.classList.add("hidden"), 3000);
}

function saveToLocalStorage() {
    localStorage.setItem("bankData", JSON.stringify(accounts));
    localStorage.setItem("transactionData", JSON.stringify(transactions));
}

function loadFromLocalStorage() {
    const data = localStorage.getItem("bankData");
    const trans = localStorage.getItem("transactionData");

    if (data) accounts = JSON.parse(data);
    if (trans) transactions = JSON.parse(trans);
}

init();
