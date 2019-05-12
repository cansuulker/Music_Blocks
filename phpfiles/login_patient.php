<?php
    include('connection.php');
    
    $username = $_POST["username"];
    $password = $_POST["password"];
                                            //terapileri al
    //check if username exists
    $namecheckquery = "SELECT username, salt, password, id FROM patients WHERE username = '" . $username . "';";

    //error code #2 - username check query failed
    $namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check query failed"); 
    if (mysqli_num_rows($namecheck) != 1)
    {
        echo "5: Either no user with name or more than one";
        exit();
    }

    //get login info from query
    $existinginfo = mysqli_fetch_assoc($namecheck);
    $userId = $existinginfo["id"];
    $salt = $existinginfo["salt"];
    $hash = $existinginfo["password"];

    $loginhash = crypt($password, $salt);
    if($hash != $loginhash)
    {
        echo "6: Incorrect password";
    }

    echo "0\t" . $existinginfo["id"];

    $priviligescheckquery = "SELECT * FROM priviliges_table WHERE user_id = '$userId' ";

$priviligescheck = mysqli_query($con, $priviligescheckquery) or die("3: priviliges check query failed"); // error code #2 = name check query failed
 
while($row = mysqli_fetch_assoc($priviligescheck)){


echo $row['admin'];
echo "*"; 
echo $row['patient'];
echo "*"; 
echo $row['therapist'];
echo "*"; 
echo $row['normal'];
echo "&";
    
}
?>