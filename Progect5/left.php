<?php
	echo "<div><form method='POST'>";
    echo "<ul><li><input class='butt' type='submit' name='createBD' value='Создать БД'></li>";
    $sql = "SHOW DATABASES";
    $connect = new mysqli('127.0.0.1', 'root', '123');
    $result = mysqli_query($connect, $sql);
    while ($database = mysqli_fetch_array($result))
    {
        echo "<li><input class='butt' type='submit' name='bases' value='$database[0]'></li>";
	}
	echo "</ul></form></div>";
    if(isset($_POST['createBD']))
    {
        echo '<meta http-equiv = "Refresh" CONTENT="0; URL = /2.php">';
    }
    else if(isset($_POST['console']))
    {
        echo '<meta http-equiv = "Refresh" CONTENT="0; URL = /SQL.php">';
    }
    else if(isset($_POST['bases']))
    {
        file_put_contents('data.txt', $_POST['bases']);
        echo '<meta http-equiv = "Refresh" CONTENT="0; URL = /1.php">';
    }
?>