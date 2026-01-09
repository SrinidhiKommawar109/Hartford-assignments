/*First*/
let company_name = "The Hartford India";
let no_of_active_policies = 50;
let health_insurance_offered = true
console.log(company_name +" "+ no_of_active_policies +" "+ health_insurance_offered);

/*Second*/
let base_premium = 6000;
let gst = 18;
let gst_amount = 0;
gst_amount = (base_premium * gst/100);
total_premium = base_premium + gst_amount;
console.log(total_premium);

/*Third 
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <script>
        let age = prompt("Enter your age"," ");
        if (age>=18)
        {
            alert("True");
        }
        else{
            alert("Flase")
        }
    </script>
</body>
</html>
*/

/*Fourth*/
let policyid = 101;
let customer_name = "nidhi";
let statusa = "active";
console.log(`Policy ${policyid} for ${customer_name} is ${statusa}`);

/*Fifth

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <script>
        let premimum = prompt("enter premium"," ");
        let discount = prompt("enter discount"," ");
        let discount_amount = 0
        discount_amount = premimum * discount/100;
        total_premium = premimum - discount_amount;
        console.log(total_premium);
    </script>
</body>
</html>
-->
*/

/*Sixth*/
const a = 10;
console.log(a);

/*Seventh
<!DOCTYPE html>
<html lang = en>
    <head>
        <title>
            calculator
        </title>
    </head>
    <body>
        <script>
            let monthly_premium = Number(prompt("enter monthly premium"," "));
            let yearly_premium = (monthly_premium) => {
                let total = monthly_premium * 12;
                return total;
            };
            let res = yearly_premium(monthly_premium) ;
            alert(res);
        </script>
    </body>
</html>
*/

/*Eighth
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <script>
        let policy_status = prompt("Enter prompt"," ");
let premium_status = prompt("Enter prompt"," ");
if (policy_status == "active" && premium_status == "paid"){
       console.log("True both conditions satisfied");
}
else{
       console.log("False both conditions are not satisfied");
}
    </script>
</body>
*/

/*Ninth
<!DOCTYPE html>
<html lang = "en">
    <head>
        <title>Assignment-5</title>
    </head>
    <body>
        <script>
            let claim_amount = Number(prompt("enter claim"," "));
            let coverage = prompt("Enter coverage", " ");
            if (claim_amount <= coverage){
                alert("Approved");
            }
            else{
                alert("Rejected")
            }
        </script>
    </body>
</html>
*/


/*tenth 
<!DOCTYPE html>
<html lang="en">
<head>
    <title>Claim Bonus Calculator</title>
</head>
<body>
<script>
    let premium = Number(prompt("Enter premium", " "));
    let noPreviousClaims = confirm("Do you have NO previous claims?\nClick OK for YES\nClick Cancel for NO");
    const calculateBonus = (premium, noPreviousClaims) => {
        return noPreviousClaims ? premium * 0.05 : 0;
    };
    let bonus = calculateBonus(premium, noPreviousClaims);
    alert(`After Bonus = ₹ ${premium} - ${bonus}`);
</script>
</body>
</html>
*/