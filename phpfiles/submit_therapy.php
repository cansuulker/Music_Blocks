<?php   

    $con = mysqli_connect('localhost', 'root', '', 'tmp');

    //check connection happened
    if (mysqli_connect_errno())
    {
        echo "1: Connection failed";
        exit();
    }

    /*$handType = $_POST["handType"];
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
 $numberOfGames = $_POST["numberOfGames"];
 $numberOfOperations = $_POST["numberOfOperations"];
 $accuracy = $_POST["accuracy"];
 $rotation = $_POST["rotation"];
 $arithmetics = $_POST["arithmetics"];
 $effects = $_POST["effects"];
 $numberOfDigits = $_POST["numberOfDigits"];
 $typeOfOperation = $_POST["typeOfOperation"];
 $numberOfOperands = $_POST["numberOfOperands"];
$insertuserquery = "INSERT INTO therapies (numberOfGames, numberOfOperations, accuracy,rotation,arithmetics,effects,numberOfDigits,typeOfOperation,numberOfOperands) VALUES ('" . $numberOfGames . "', '" . $numberOfOperations . "', '" . $accuracy . "','" . $rotation ."', '" . $arithmetics . "', '" . $effects . "', '" . $numberOfDigits . "','" . $typeOfOperation ."', '" . $numberOfOperands . "');";


    mysqli_query($con, $insertuserquery) or die("4: Insert player query failed");

    echo("0");
?>  