<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
	<title>LB_5</title>
	<link rel="stylesheet" type="text/css" href="style.css">
</head>
<body>

	<div class="container">
  		<div class="column col-1">
    		<h2>Список БД</h2>
    		<div class="vl">
    			<?php include'left.php'; ?>
    		</div>
  		</div>
  		<div class="column col-2">
    		<form method="POST">
    			<h3>Создать таблицу</h3>
    			<p>
    			<input class="butt2" type="submit" name="createT" value="Создать таблицу"/>
    			</p>
    			<p><input class="butt2" type="text" name="sql" placeholder="sql"/>
					<input class="butt2" type="submit" value="Вперед"/></p>
					<p>
					<input class="butt2" type="submit" name="dropBD" value="Удалить БД"/>
				</p>

				<?php
					$name = file_get_contents('data.txt');
					if (isset($_POST['table']))
					{
						file_put_contents('table.txt', $_POST['table']);
						echo '<meta http-equiv = "Refresh" CONTENT="0; URL = /table.php">';
					}
					else if (isset($_POST['createT']))
					{
						echo $_POST['createT'];
						file_put_contents('table.txt', $_POST['createT']);
						echo '<meta http-equiv = "Refresh" CONTENT="0; URL = /create.php">';
					}
					else if (isset($_POST['dropBD']))
					{
						$mysqli = new mysqli("localhost", "root", "123");
						$mysqli->query("DROP DATABASE `$name`");
						echo '<meta http-equiv = "Refresh" CONTENT="0; URL = /2.php">';
					}
					else if (isset($_POST['sql']))
					{
						//Подключение к бд
						$bd = mysqli_connect('127.0.0.1', 'root', '123', $name);


						//Запрос
						$mysqli = mysqli_query($bd, $_POST['sql']);
						if (1)
						{
							echo 1;
							echo "<table border='1'><tr>";
						    $flag = false;
							while($arg = mysqli_fetch_array($mysqli))
							{
								//Строки таблицы
								echo "<tr>";
								foreach($arg as $value)
								{
									if (!$flag)
									{
										echo "<td>".$value."</td>";
										$flag = true;
									}
									else $flag = false;

								}
								echo "</tr>";
							}
							echo "</tr></table>";
						}
						else
						{
							echo 0;
							$mysqli->query($bd, $_POST['sql']);
						}

					}



					echo "<form method='POST'>";
					echo "<table border='1'><tr>";

					$connect = new mysqli('127.0.0.1', 'root', '123', $name);
					$result = mysqli_query($connect, "SHOW TABLES FROM `$name`");
					$tableLine='';

				    while ($table = mysqli_fetch_array($result))
				    {
				    	$tableLine .= "<tr><td><input class='butt' type='submit' name='table' value='$table[0]'></td></tr>";
				    }
				    echo $tableLine;
				    echo "</tr></table></form>";

				?>

			</form>
  		</div>
	</div>


</body>
</html>

