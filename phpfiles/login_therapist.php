<?php
    include('connection.php');
    
    $username = $_POST["username"];
    $password = $_POST["password"];
                                            //terapileri al
    //check if username exists
    $namecheckquery = "SELECT username, salt, password, id FROM therapists WHERE username = '" . $username . "';";

    //error code #2 - username check query failed
    $namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check query failed"); 
    if (mysqli_num_rows($namecheck) != 1)
    {
        echo "5: Either no user with name or more than one";
        exit();
    }

    //get login info from query
    $existinginfo = mysqli_fetch_assoc($namecheck);
    $salt = $existinginfo["salt"];
    $hash = $existinginfo["password"];

    $loginhash = crypt($password, $salt);
    if($hash != $loginhash)
    {
        echo "6: Incorrect password";
    }

    echo "0\t" . $existinginfo["id"];
?>