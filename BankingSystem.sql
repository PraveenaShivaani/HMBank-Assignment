-------------------task 1-------------------
--creating a database
create database  HMBank

--change database
use HMBank

--Defining all the three tables
--creating table Customer
create table Customers(customer_id int primary key not null,
first_name varchar(50),
last_name varchar(50),
DOB date,
email varchar(60),
phone_number int,
address varchar(100))

--creating table Accounts
create table Accounts(
account_id int primary key not null,
customer_id int,
account_type varchar(30),
balance int,
Foreign key(customer_id) references Customers(customer_id))


--creating table Transactions
create table Transactions(
transaction_id int primary key not null,
account_id int,
transaction_type varchar,
amount int,
transacction_date date,
Foreign key(account_id) references Accounts(account_id))

--as i dint give the attribute value
alter table Transactions
alter column transaction_type varchar(20)

---as i forgrt this column
alter table Accounts
add account_type varchar(30)

alter table Accounts
add balance int

--Inserting into Customer table
Insert into Customers values(1,'praveena','shivaani','2003-07-12','praveena@gmail.com',94567,'namakkal')

---as i gave int for phnumber it shows error
Alter table Customers
Alter column Phone_number BigInt

update Customers set phone_number=9345776788

select * from Customers

--Inserting 9 values to cutomers
Insert into Customers values(2,'Karthick','Raja','2001-01-1','karthick@gmail.com',9456734567,'salem'),
(3,'ajay','prasath','2002-02-5','ajayprasath@gmail.com',9943775621,'madurai'),
(4,'sowndarya','Ramadass','2003-06-8','sowndaryaram@gmail.com',9442255678,'chidambaram'),
(5,'rajasri','Ravi','2004-07-12','rajasriravi@gmail.com',7890624754,'sirkazhi'),
(6,'gopinath','gunasekaran','2005-02-13','gopinathgunasekaran@gmail.com',9456732937,'thanjavur'),
(7,'rahul','Raja','2004-05-26','prorahul@gmail.com',9006781234,'salem'),
(8,'aboorva','krishna','2008-09-17','abborvakrishna@gmail.com',9678901267,'namakkal'),
(9,'hari','haran','2000-05-10','hariharan@gmail.com',6789054321,'madurai'),
(10,'pavith','Ramkrishna','2009-06-1','pavithkrishna@gmail.com',9987656432,'salem')

--Inserting 10 values in Account table
insert into Accounts values(12345,1,'savings',10000)
Insert into Accounts values(67892,2,'current',5500),
(67890,3,'current',6500),
(23456,4,'savings',5000),
(87964,5,'zer_balance',300),
(87942,6,'current',5500),
(74321,7,'zero_balance',7800),
(09842,8,'current',700),
(21453,9,'savings',1000),
(32187,10,'current',2200)

--Insert 10 values in Transcaction
Insert into Transactions values(101,12345,'deposite',1000,'2024-04-24'),
(102,67890,'withdrawal',1000,'2024-04-4'),
(103,23456,'deposite',1000,'2024-03-18'),
(104,87964,'deposite',1000,'2024-04-29'),
(105,87942,'withdrawal',1000,'2024-05-2'),
(106,74321,'deposite',1000,'2024-04-23'),
(107,09842,'transfer',1000,'2024-04-28'),
(108,21453,'withdrawal',1000,'2024-01-14'),
(109,32187,'transfer',1000,'2024-04-1'),
(110,67892,'withdrawal',1000,'2024-03-20')

select * from Transactions



---------------TASK-2-----------------------

--1. Write a SQL query to retrieve the name, account type and email of all customers.   
select C.first_name as name ,A.account_type,C.email 
from Customers C
join Accounts A ON C.customer_id=A.customer_id

--2. Write a SQL query to list all transaction corresponding customer. 
select A.customer_id,T.transaction_id,T.transaction_type,T.transacction_date
from Transactions T
Join Accounts A ON T.account_id=A.account_id


--3 Write a SQL query to increase the balance of a specific account by a certain amount. 
select * from Accounts
Update Accounts
set balance=balance+1000
where account_id=9842

--4.Write a SQL query to Combine first and last names of customers as a full_name. 
select CONCAT(first_name,' ',last_name) as name from Customers
-- 
select CONCAT_ws('-',first_name,last_name) as name from Customers

--5.Write a SQL query to remove accounts with a balance of zero where the account type is savings. 
alter table Transactions
Add constraint fk_transaction_account_id
Foreign key(Account_id) references Accounts(account_id) on delete cascade

DELETE FROM Accounts 
WHERE balance = 5000 
AND account_type = 'Savings'

DELETE FROM Accounts 
WHERE balance = 0 
AND account_type = 'Savings'

--6. Write a SQL query to Find customers living in a specific city. 
Select * from Customers
where address='namakkal'

--7. Write a SQL query to Get the account balance for a specific account.
select balance from Accounts
where account_id=12345

--8. Write a SQL query to List all current accounts with a balance greater than $1,000. 
select * from Accounts
where account_type='current'
AND balance>1000

--9. Write a SQL query to Retrieve all transactions for a specific account. 
select * from Transactions
where transaction_id=101

--10. Write a SQL query to Calculate the interest accrued on savings accounts based on a given interest rate.
alter table Accounts
ADD interest_rate Decimal(4,1)--!

update Accounts
set interest_rate=12.3
where account_type='savings'

update Accounts
set interest_rate=10.5
where account_type='current'

update Accounts
set interest_rate=15.2
where account_type='zero_balance'


SELECT account_id, balance * interest_rate / 100 AS interest_accrued FROM Accounts
WHERE account_type = 'Savings'

--11. Write a SQL query to Identify accounts where the balance is less than a specified  overdraft limit.
select * from Accounts
where balance<10000

--12. Write a SQL query to Find customers not living in a specific city. 
select * from Customers
where address != 'salem'

-----------------TASK-3--------------------

--1. Write a SQL query to Find the average account balance for all customers.  
select account_id,customer_id,AVG(balance) as average
from Accounts
group by account_id,customer_id

--2. Write a SQL query to Retrieve the top 10 highest account balances. 
select top 10 account_id,balance from Accounts
ORDER BY balance desc

--3. Write a SQL query to Calculate Total Deposits for All Customers in specific date. 

select transacction_date as tdate ,sum(amount) as amount
from Transactions
where transacction_date='2024-04-24' and transaction_type='deposite'
group by transacction_date

--4. Write a SQL query to Find the Oldest and Newest Customers.

/*select A.account_id,T.min(transacction_date) as old
from Accounts A
join Transactions T on A.account_id=T.account_id--!!*/

Select Top 1 * 
From Customers
Order by customer_id asc -- Oldest Customer

select top 1 * 
From Customers
Order by customer_id desc -- Newest Customer

--5.Write a SQL query to Retrieve transaction details along with the account type.
Select transactions.transaction_id,
transactions.account_id,
transactions.amount,
transactions.transaction_type,
transactions.transacction_date,
accounts.account_type
from 
Transactions,Accounts--use join


 --6. Write a SQL query to Get a list of customers along with their account details. 
Select C.customer_id,
C.first_name,
A.account_id,
A.account_type,
A.balance
From
customers C
Join Accounts A ON A.customer_id=C.customer_id


--7. Write a SQL query to Retrieve transaction details along with customer information for a specific account.
SELECT *
from Transactions T
join Accounts A On T.account_id=A.account_id
Join Customers C On C.customer_id = A.customer_id
WHERE A.account_id=12345
--where A.account_type='current'


--8. Write a SQL query to Identify customers who have more than one account. 

SELECT C.customer_id, COUNT(A.account_id) AS num_accounts
FROM Customers C
JOIN Accounts A ON C.customer_id = A.customer_id
GROUP BY C.customer_id
HAVING COUNT(A.account_id) > 1

--or
select customer_id
from Accounts
group by customer_id
having count(*)>1

--inserted inorder to get the output for customer having more than one account
insert into Accounts values(67895,3,'current',6500,null)

select * from Accounts

--9. Write a SQL query to Calculate the difference in transaction amounts between deposits and withdrawals. 
select * from Transactions
select
sum(case when transaction_type='deposite' then amount else 0 end) -
sum(case when transaction_type='withdrawal' then amount else 0 end) 
from transactions

--or

select (select sum(amount)
from Transactions
where transaction_type='deposite') - (select sum(amount)
from Transactions
where transaction_type='withdrawal') as difference from Transactions


--10. Write a SQL query to Calculate the average daily balance for each account over a specified period.

select A.account_id, AVG(A.balance) as average,A.account_type 
From Accounts A
Join Transactions T On A.account_id = T.account_id
Where T.transacction_date BETWEEN '2024-03-01' AND '2024-04-01'
GROUP BY A.account_id,account_type

--11. Calculate the total balance for each account type. 
select account_type,sum(balance)  AS balance
from Accounts
group by account_type

--12. Identify accounts with the highest number of transactions order by descending order. 
select top 1 account_id,count(transaction_id) as iteration
from Transactions
group by account_id
order by iteration  desc

--13. List customers with high aggregate account balances, along with their account types.
select top 1 C.customer_id,C.first_name,A.account_type,SUM(A.balance) AS Agg_balance
from Customers C
JOIN Accounts A ON C.customer_id = A.customer_id
group by C.customer_id,C.first_name,A.account_type
order by Agg_balance desc
 

--14. Identify and list duplicate transactions based on transaction amount, date, and account. 
select transacction_date, amount, account_id, count(*) as iterations 
from Transactions 
group by transacction_date, amount, account_id
Having COUNT(*)>1
order by transacction_date, amount, account_id

--As there is duplicate columns im adding it

Insert into Transactions values(114,12345,'withdrawal',1000,'2024-04-24')
select * from Transactions




-----------------------my rough work---------------------------------
-- Setting Constraint for Account Type
ALTER TABLE Transactions
ADD CONSTRAINT CK_Transactions_transactions_Type
CHECK(transaction_type IN('deposite','withdrawal','transfer'))


--INNER join
select A.customer_id,T.amount 
from Accounts A 
join
Transactions T
on A.account_id=T.account_id

--LEFT JOIN
select A.customer_id,T.amount 
from Accounts A 
left join
Transactions T
on A.account_id=T.account_id

--cross join
select A.customer_id,T.amount 
from Accounts A 
cross join
Transactions T

--full outer join JOIN
select A.customer_id,T.amount 
from Accounts A 
full outer join
Transactions T
on A.account_id=T.account_id

--using some condition
select A.customer_id,sum(T.amount*2) as amount
from Accounts A 
left join
Transactions T
on A.account_id=T.account_id 
where amount>100
group by customer_id

select * from Transactions

update Transactions
set amount=2000
where account_id=102--!!




------------------------------------TASK-4-------------------------------------

--1. Retrieve the customer(s) with the highest account balance. 
select first_name,last_name,phone_number
from Customers
where customer_id = (Select top 1 customer_id
from Accounts
order by balance desc)

--2. Calculate the average account balance for customers who have more than one account. 

select avg(balance) as average,customer_id
from Accounts
group by customer_id
Having customer_id = 
(select customer_id
from Accounts
group by customer_id
having count(*)>1)

--3. Retrieve accounts with transactions whose amounts exceed the average transaction amount. 
select account_id
from Transactions
where amount >
(select avg(amount)
from Transactions)

--as i gave 1000 for all the accounts 
insert into Transactions values(111,67890,'withdrawal',2000,'2024-03-4')

--4. Identify customers who have no recorded transactions. 

SELECT C.customer_id,C.first_name,C.last_name,T.account_id,T.transaction_id
FROM Customers C
full outer JOIN Accounts A ON C.customer_id = A.customer_id
full outer JOIN Transactions T ON A.account_id = T.account_id
WHERE T.account_id IS NULL;

--as there is no account without trasaction hence i inserted it
Insert into Customers values(11,'praveena','Gnanam','2003-06-12','praveenasekar@gmail.com',9456789039,'namakkal')
Insert into Accounts values(57892,11,'current',0,null)--!!

--5. Calculate the total balance of accounts with no recorded transactions. 
SELECT A.account_id,sum(balance) as balance
from Accounts A
left join Transactions T on A.account_id=T.account_id
where T.transaction_id is null
group by A.account_id

--6. Retrieve transactions for accounts with the lowest balance. 
select *
from Transactions
where account_id = (
SELECT top 1 account_id
from Accounts
order by balance)

--as there is no such acc in transaction which is selected in subquery..I added it
Insert into Transactions values(112,12345,'deposite',4000,'2024-09-4')
Insert into Transactions values(113,57892,'transfer',4620,'2024-01-14')
Insert into Transactions values(115,57692,'transfer',620,'2024-03-6')


--7. Identify customers who have accounts of multiple types. 

SELECT C.customer_id,C.first_name,C.last_name
FROM Customers C
JOIN Accounts A ON C.customer_id = A.customer_id
GROUP BY C.customer_id,C.first_name,C.last_name
HAVING COUNT(DISTINCT A.account_type) > 1

-- inorder to give output

Insert into Customers values(12,'shivani','krish','2003-01-1','shivanikrish@gmail.com',9456789019,'chennai')
Insert into Accounts values(57692,11,'savings',0,null)

--8. Calculate the percentage of each account type out of the total number of accounts.

select account_type, 
COUNT(*) * 100/ (SELECT COUNT(*) FROM Accounts) AS Percentage_of_Accounts
From Accounts
Group By account_type

--9. Retrieve all transactions for a customer with a given customer_id.
select *
from  Transactions T
join Accounts A on T.account_id=A.account_id
Where customer_id=1


--10. Calculate the total balance for each account type, including a subquery within the SELECT clause.
select account_type,(select sum(balance)  from Accounts where A.account_type = account_type) as total_balance
from Accounts A
group by account_type

