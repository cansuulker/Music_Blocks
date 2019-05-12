<?php   

    $con = mysqli_connect('localhost', 'root', '', 'slashing_game');

    //check connection happened
    if (mysqli_connect_errno())
    {
        echo "1: Connection failed";
        exit();
    }

    $therapy_id = $_POST["therapy_id"];

    $therapyquery = "SELECT id, hand, difficulty, hand_track, concept, speed, cognitive, stance, up_left, up, up_right, mid_left, mid_right, down_left, down, down_right FROM therapies WHERE id = '" . $therapy_id . "'";
    $sth = mysqli_query($con, $therapyquery) or die("2: therapy query failed"); 
    $thr = mysqli_fetch_assoc($sth);

    echo "1\t" . $thr["id"] . "\t" . $thr["hand"]. "\t" . $thr["difficulty"]. "\t" . $thr["hand_track"]. "\t". $thr["concept"]. "\t" . $thr["speed"]. "\t" . $thr["cognitive"]. "\t" . $thr["stance"] . "\t" . $thr["up_left"] . "\t" . $thr["up"] . "\t" . $thr["up_right"] . "\t" . $thr["mid_left"] . "\t" . $thr["mid_right"] . "\t" . $thr["down_left"] . "\t" . $thr["down"] . "\t" . $thr["down_right"];
?>  