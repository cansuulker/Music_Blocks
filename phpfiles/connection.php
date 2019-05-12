<?php
$con = mysqli_connect('localhost', 'root', '', 'tmp');

//check connection happened
if (mysqli_connect_errno())
{
    echo "1: Connection failed";
    exit();
}  
?>