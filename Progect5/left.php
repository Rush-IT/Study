
<?php
	echo "<ul><li><a href='2.php' class='button15'>Создать БД</a></li>";
    $sql = "SHOW DATABASES";
    $connect = new mysqli('127.0.0.1', 'root', '123');
    $result = mysqli_query($connect, $sql);
    while ($database = mysqli_fetch_array($result))
    {
    	echo "<li>$database[0]<ul>";
    	$result1 = mysqli_query($connect, "SHOW TABLES FROM $row[0]");
	    while ($table = mysqli_fetch_array($result1))
	    {
	    	echo "<li>$table[0]</li>";
	    }
	    echo "</ul></li>";
	}
	echo "</ul>";
?>