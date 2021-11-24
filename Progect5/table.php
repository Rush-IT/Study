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
  			<form method='POST'>

				<p>
				<input class='butt2' type='submit' name='addC' value='Добавить столбец'/><input class='butt2' type='submit' name='addS' value='Добавить строку'/><p/>
    		</form>
				<?php
					//Названия бд и таблицы с которыми нужно работать
					$table = file_get_contents('table.txt');
					$data = file_get_contents('data.txt');
					$number = 0;
					// Переход к бд из списка
					if (isset($_POST['bases']))
					{
						file_put_contents('data.txt', $_POST['bases']);
						echo '<meta http-equiv = "Refresh" CONTENT="0; URL = /1.php">';
					}
					//Переход к созданию бд
					else if (isset($_POST['createBD']))
					{
						echo '<meta http-equiv = "Refresh" CONTENT="0; URL = /2.php">';
					}
					//Добавление строк
					else if(isset($_POST['addS']))
					{
						echo '<meta http-equiv = "Refresh" CONTENT="0; URL = /crtS.php">';
					}

					else if(isset($_POST['addC']))
					{
						echo '<meta http-equiv = "Refresh" CONTENT="0; URL = /crtC.php">';

					}

					else if(isset($_POST['deleteT']))
					{
						$mysqli = new mysqli("localhost", "root", "123", $data);
						$mysqli->query("DELETE FROM ".$table);
					}

					else if(isset($_POST['dropT']))
					{
						$mysqli = new mysqli("localhost", "root", "123", $data);
						$mysqli->query("DROP TABLE ".$table);
						echo '<meta http-equiv = "Refresh" CONTENT="0; URL = /1.php">';
					}
					else if(isset($_POST['back']))
					{
						echo '<meta http-equiv = "Refresh" CONTENT="0; URL = /1.php">';
					}



					//Подключение к бд
					$bd = mysqli_connect('127.0.0.1', 'root', '123', file_get_contents('data.txt')) or die(mysqli_error());
					//Запрос
					$mysqli = mysqli_query($bd, "SELECT * FROM `$table`");

					//Вывод результата запроса
					echo "<table border='1'>";
					$colums = mysqli_query($bd, "SHOW COLUMNS FROM ".$table."");
                    while($row = mysqli_fetch_assoc($colums))
                    {
                    	//Название столбцов
                        echo "<td>".$row["Field"]."</td>";
                        //Количество столбцов
                        $number++;
                    }
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
					echo "</table>";
				?>
				<form method='POST'>
				<p>

					<input class='butt2' type='submit' name='dropT' value='Удалить таблицу'/>
					<input class='butt2' type='submit' name='deleteT' value='Очистить таблицу'/>
    			</p>
    			<p><input class='butt2' type='submit' name='back' value='Назад'/></p>
    		</form>

  		</div>
	</div>

</body>
</html>