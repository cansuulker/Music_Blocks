<?php   

    $con = mysqli_connect('localhost', 'root', '', 'tmp');

    //check connection happened
    if (mysqli_connect_errno())
    {
        echo "1: Connection failed";
        exit();
    }

    //check if username exists
    $namecheckquery = "SELECT * FROM therapies";

    //error code #2 - username check query failed
    $sth = mysqli_query($con, $namecheckquery) or die("2: Name check query failed"); 
    $rows = array();

    while($r = mysqli_fetch_assoc($sth)) {
        echo $r["therapy_name"] . "\t";
    }

?>  