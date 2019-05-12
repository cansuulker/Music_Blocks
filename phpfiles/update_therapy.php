<?php   

    $con = mysqli_connect('localhost', 'root', '', 'slashing_game');

    //check connection happened
    if (mysqli_connect_errno())
    {
        echo "1: Connection failed";
        exit();
    }
   /* $therapy_id = $_POST["id"];
    $handType = $_POST["handType"];
    $difficulty = (int)$_POST["difficulty"];
    $handTracker = $_POST["handTracker"];
    $concept = $_POST["concept"];
    $speed = (int)$_POST["speed"];
    $cognitive = $_POST["cognitive"];
    $stance = $_POST["stance"];
    $upLeft = (int)$_POST["upLeft"];
    $up = (int)$_POST["up"];
    $upRight = (int)$_POST["upRight"];
    $midLeft = (int)$_POST["midLeft"];
    $midRight = (int)$_POST["midRight"];
    $downLeft = (int)$_POST["downLeft"];
    $down = (int)$_POST["down"];
    $downRight = (int)$_POST["downRight"];*/

    // $namecheckquery = "SELECT therapy_id FROM therapies WHERE therapy_id = '$therapy_id'";
    // $result= mysqli_query($con, $namecheckquery) or die("4: Insert player query failed" . $patient_id . $therapy_id);
    // $thr = mysqli_fetch_assoc($result);

    // $insertuserquery = "INSERT INTO therapies (hand, difficulty, hand_track,concept, speed, cognitive, stance,up_left, up, up_right, mid_left,mid_right, down_left, down, down_right) VALUES ('" . $handType . "', '" . $difficulty . "', '" . $handTracker . "','" . $concept ."', '" . $speed . "', '" . $cognitive . "', '" . $stance . "','" . $upLeft ."', '" . $up . "', '" . $upRight . "', '" . $midLeft . "','" . $midRight ."', '" . $downLeft . "', '" . $down . "', '" . $downRight . "');";
    // mysqli_query($con, $insertuserquery) or die("4: Insert player query failed" . $handType . $difficulty);
 $numberOfGames = $_POST["numberOfGames"];
 $numberOfOperations = $_POST["numberOfOperations"];
 $accuracy = $_POST["accuracy"];
 $rotation = $_POST["rotation"];
 $arithmetics = $_POST["arithmetics"];
 $effects = $_POST["effects"];
 $numberOfDigits = $_POST["numberOfDigits"];
 $typeOfOperation = $_POST["typeOfOperation"];
 $numberOfOperands = $_POST["numberOfOperands"];
    $sql = "UPDATE therapies SET numberOfGames = '$numberOfGames', numberOfOperations = '$numberOfOperations', accuracy = '$accuracy', rotation = '$rotation', arithmetics = '$arithmetics', effects = '$effects', numberOfDigits = '$numberOfDigits', typeOfOperation = '$typeOfOperation', numberOfOperands = '$numberOfOperands'";
    mysqli_query($con, $sql) or die("6: Insert player query failed");

    echo("0");
?>  