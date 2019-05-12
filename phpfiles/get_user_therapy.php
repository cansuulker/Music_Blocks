<?php   

    $con = mysqli_connect('localhost', 'root', '', 'tmp');

    //check connection happened
    if (mysqli_connect_errno())
    {
        echo "1: Connection failed";
        exit();
    }

    $patient_id = $_POST["patient_id"];
    //check if username exists
    $namecheckquery = "SELECT therapy_id FROM patient_therapy WHERE patient_id = '" . $patient_id . "'";

    //error code #2 - username check query failed
    $sth = mysqli_query($con, $namecheckquery) or die("2: Name check query failed"); 
    $row = mysqli_fetch_assoc($sth);
    $therapy_id = $row['therapy_id'];


    $therapyquery =    "SELECT id ,numberOfGames, numberOfOperations ,accuracy , rotation, arithmetics, effects, numberOfDigits, typeOfOperation, numberOfOperands FROM therapies WHERE id = '" . $therapy_id . "'";"
    $sth = mysqli_query($con, $therapyquery) or die("2: therapy query failed"); 
    $thr = mysqli_fetch_assoc($sth);



    echo "1\t" . $thr["id"] . "\t" . $thr["numberOfGames"]. "\t" . $thr["numberOfOperations"]. "\t" . $thr["accuracy"]. "\t". $thr["rotation"]. "\t" . $thr["arithmetics"]. "\t" . $thr["effects"]. "\t" . $thr["numberOfDigits"] . "\t" . $thr["typeOfOperation"] . "\t" . $thr["numberOfOperands"];
?>  