<?php   

    $con = mysqli_connect('localhost', 'root', '', 'slashing_game');

    //check connection happened
    if (mysqli_connect_errno())
    {
        echo "1: Connection failed";
        exit();
    }

    //$patient_id = $_POST["patient_id"];

    $name = $_POST["name"];
    $surname = $_POST["surname"];
    $therapy_id = $_POST["therapy_id"];
    
    $namecheckquery = "SELECT id FROM patients WHERE name='$name' AND surname='$surname'";
    $result= mysqli_query($con, $namecheckquery) or die("4: Insert player query failed" . $patient_id . $therapy_id);
    $thr = mysqli_fetch_assoc($result);

    $patient_id = $thr["id"];

    $namecheckquery = "SELECT therapy_id FROM patient_therapy WHERE patient_id='$patient_id' LIMIT 1";
    $result= mysqli_query($con, $namecheckquery) or die("4: Insert player query failed" . $patient_id . $therapy_id);
    $thr = mysqli_fetch_assoc($result);
    if($thr)
    {
        $sql = "UPDATE patient_therapy SET therapy_id = '$therapy_id' WHERE patient_id ='$patient_id' ";
        mysqli_query($con, $sql) or die("6: Insert player query failed" . $patient_id . $therapy_id);
        
    }
    else{
        $sql = "INSERT INTO patient_therapy (patient_id, therapy_id) VALUES '" . $patient_id . "', '" . $therapy_id . "');";
        mysqli_query($con, $sql) or die("5: Insert player query failed" . $patient_id . $therapy_id);
    }
    
    echo("0");
?>  