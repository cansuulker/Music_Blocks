<?php   

    $con = mysqli_connect('localhost', 'root', '', 'tmp');

    //check connection happened
    if (mysqli_connect_errno())
    {
        echo "1: Connection failed";
        exit();
    }

    $therapist_id = $_POST["therapist_id"];
    //check if username exists
    $namecheckquery = "SELECT patient_id FROM therapist_patient WHERE therapist_id = '" . $therapist_id . "'";

    //error code #2 - username check query failed
    $sth = mysqli_query($con, $namecheckquery) or die("2: Name check query failed"); 
    $rows = array();
    while($r = mysqli_fetch_assoc($sth)) {
        $rows[] = $r["patient_id"];
    }

    for ($x = 0; $x < sizeof($rows); $x++) {
        $id = $rows[$x];
        $namecheckquery = "SELECT name, surname FROM patients WHERE id = '" . $id . "'";
        $sth = mysqli_query($con, $namecheckquery) or die("2: id check query failed"); 
        $thr = mysqli_fetch_assoc($sth);

        echo $thr["name"] . "\t" . $thr["surname"] . "\t";
    } 
?>  