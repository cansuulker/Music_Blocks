<?php   
    $con = mysqli_connect('localhost', 'root', '', 'tmp');

    //check connection happened
    if (mysqli_connect_errno())
    {
        echo "1: Connection failed";
        exit();
    }

    $name = $_POST["name"];
    $surname = $_POST["surname"];
    $username = $_POST["username"];
    $password = $_POST["password"];

    //check if name exists
    $namecheckquery = "SELECT username FROM patients WHERE username = '" . $username . "';";

    //error code #2 - name check query failed
    $namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check query failed"); 

    if(mysqli_num_rows($namecheck) > 0)
    {
        echo "3: Name already exists";
        exit();
    }

    //add patient to the table
    $salt = "\$5\$rounds=5000\$" . "steamedhams" . $username . "\$";
    $hash = crypt($password, $salt);
    $insertuserquery = "INSERT INTO patients (name, surname, username, password, salt) VALUES ('" . $name ."', '" . $surname . "', '" . $username . "', '" . $hash . "', '" . $salt . "');";
    mysqli_query($con, $insertuserquery) or die("4: Insert player query failed");

    echo("0");
?>