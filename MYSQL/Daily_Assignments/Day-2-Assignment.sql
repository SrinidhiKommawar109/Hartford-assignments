
 1. select * from Customer;
 2. select Customer_id,policy_id,startdate,enddate from PolicyAssignment;
 3. select policy_id,PolicyName,PolicyType from Policies where PolicyName = 'Health';
 4. select policy_id , PolicyName , PreAmount from Policies where PreAmount > 10000 and durationyears = 1;
 5. select distinct(city) from Agents;
 6. select PolicyName from Policies where PolicyType = 'Life Insurance' or PolicyName = 'Health' or PolicyName = 'Motor'  
 7. select PolicyName from Policies where PolicyType in('Life Insurance' , 'Health', 'Motor')
 8. select FirstName , LastName from Customer where Dateofbirth > '2001-01-01' and Dateofbirth < '2020-12-31'; 
 9. select FirstName , LastName from Customer where Dateofbirth between '2001-01-01'and '2020-12-31'
 10.select * from Claims where claimstatus = 'Pending' or claimstatus = 'Rejected';

 11. select agentname from Agents where city like '_y%';
 12. select max(claimamount) as max_claim_amount , min(claimamount) as min_claim_amount from Claims;
 13. select * from Claims order by claimDate desc;
 14. select PreAmount + (PreAmount /100)*10 as premium_amount from Policies where PolicyType like '%Life%';
 15. delete from  PolicyAssignment where EndDate < CAST(GETDATE() AS DATE);
 16. select count(*) as count from Claims where claimstatus in ('rejected','pending');
 17. select Policy_id,PolicyName,
    PreAmount,PreAmount * 0.06 AS LocalTaxes,
    PreAmount + (PreAmount * 0.06) AS PremiumAmountWithTax,(PreAmount + (PreAmount * 0.06)) / 12 AS MonthlyPremiumAmount
    FROM Policies;
 18. Alter table Customer add City varchar(50) , Address varchar(50);
 19. Alter table Agents add DevOfId varchar(50)
 
 --1. List all Policies for a CustomerId 5(inplace of 5 took 101 based on my insert queries).

select c.FirstName , c.LastName , p.PolicyName from Customer c
join PolicyAssignment pa on pa.Customer_id = c.Customer_id
join Policies p on pa.policy_id = p.policy_id where c.Customer_id = 105;

--2. View all customers with their policies.
select c.FirstName , c.LastName , p.PolicyName from Customer c
join PolicyAssignment pa on pa.Customer_id = c.Customer_id
join Policies p on pa.policy_id = p.policy_id ;

--3.View claims with customer name it also accepts null.
select cu.FirstName,cu.LastName , C.claimid,C.claimDate,C.claimamount,C.claimstatus from Customer cu 
left join PolicyAssignment pa on pa.Customer_id = cu.Customer_id 
left join Claims C on pa.AssId = C.assignmentid;

--4. Display FirstName, PolicyName, AgentName, StartDate and EndDate from their respective tables.
select c.FirstName,c.LastName,p.PolicyName,a.agentname,pa.startdate,pa.enddate
from Customer c join PolicyAssignment pa on pa.Customer_id = c.Customer_id 
join Policies p on pa.policy_id = p.policy_id 
join Agents a on pa.agentid = a.agentid;

--5.Display claims report with FirstName, PolicyName, ClaimAmount, ClaimStatus, and ClaimDate from their respective tables.
select c.FirstName , p.PolicyName , cl.claimAmount , cl.claimstatus , cl.claimDate 
from Customer c join policyAssignment pa on pa.Customer_id = c.Customer_id 
join Policies p on pa.policy_id = p.policy_id
join Claims cl on pa.AssId = cl.assignmentid;

--6 .Display records of Customers with or without Policies.
select cu.FirstName,cu.LastName,P.PolicyName, P.PolicyType from Customer cu 
left join PolicyAssignment pa on pa.Customer_id = cu.Customer_id 
left join Policies P on P.policy_id= pa.policy_id;

--7.Display all Customers with NO Claims.

select distinct c.Customer_id,c.FirstName,c.LastName from Customer c 
left join PolicyAssignment pa on pa.Customer_id = c.Customer_id
left join Claims cl on pa.AssId = cl.assignmentid
where cl.claimId is null;

--8.Show CustomerName with Total Claim Amount per Customer.

select  c.Customer_id,c.FirstName,c.LastName,Sum(cl.ClaimAmount) as TotalClaimAmount from Customer c
left join PolicyAssignment pa on pa.Customer_id = c.Customer_id
left join Claims cl on pa.AssId = cl.assignmentid 
group by c.Customer_id,c.FirstName,c.LastName;

--9.Show names and total claim amount of Customers With Claim Amount &gt; 50000 (Use HAVING Clause).
select  c.Customer_id,c.FirstName,c.LastName,Sum(cl.ClaimAmount) as TotalClaimAmount from Customer c
left join PolicyAssignment pa on pa.Customer_id = c.Customer_id
left join Claims cl on pa.AssId = cl.assignmentid 
group by c.Customer_id,c.FirstName,c.LastName having sum(cl.ClaimAmount) > 50000;

--10.Display list with Agent Wise Policy Count.
select  a.agentid,a.agentname,count(pa.policy_id) as Policy_Cont
from Agents a left join PolicyAssignment pa on pa.agentid = a.agentid
group by a.agentid , a.agentname;

