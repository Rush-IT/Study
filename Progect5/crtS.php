<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
	<title>Document</title>
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
  				<?php
  				$data = file_get_contents('data.txt');
				$table = file_get_contents('table.txt');
				$number = 0;

				//Подключение к бд
					$bd = mysqli_connect('127.0.0.1', 'root', '123', file_get_contents('data.txt')) or die(mysqli_error());

				echo "<table border='1'>";

				//Названия столбцов
				$arr = ["Столбец", "Значение"];
				echo "<tr>";
				for($n = 0; $n<2; $n++)
					echo "<td>$arr[$n]</td>";
				echo "</tr>";

				//Названия столбцов и их значения
				$colums = mysqli_query($bd, "SHOW COLUMNS FROM ".$table);
				$Name = "value";
                while($row = mysqli_fetch_assoc($colums))
                {
                	echo "<tr>";
                    //Название столбцов
                    echo "<td>".$row["Field"]."</td>";

                    //Ячейка для поля значения
                    $textName = $Name.$number;
                    echo "<td><input class='butt' type='text' name='$textName'/></td>";
                    //Количество столбцов
                    $number++;
                    echo "</tr>";
                }
                echo "</table>";
                echo "<p><input class='butt2' type='submit' name='name' value='Создать' /></p>";
				//Создание таблицы
				if($_POST['name'])
				{

					$firstValue = "";
					$sqlValue = "";
					$flag = false;
					$number = 0;
					$colums = mysqli_query($bd, "SHOW COLUMNS FROM ".$table);
					while($row = mysqli_fetch_assoc($colums))
					{
						if($_POST[$Name."$number"]!="")
						{

							if($flag)
							{
								$firstValue.=', ';
								$sqlValue.=', ';
							}
							//Значение для названий столбцов
							$textName = "`".$row["Field"]."`";
							$firstValue .= $textName;
							//Значение для запроса
							$textName = $Name."$number";
							$sqlValue .= '"'.$_POST["$textName"].'"';

							$number++;
							$flag = true;
						}
					}
					if($flag)
					{
						//echo "INSERT INTO `$table` (".$firstValue.") VALUES (".$sqlValue.");";
						$mysqli = new mysqli("localhost", "root", "123", $data);
						$mysqli->query("INSERT INTO `$table` (".$firstValue.") VALUES (".$sqlValue.");");
						echo '<meta http-equiv = "Refresh" CONTENT="0; URL = /table.php">';
					}
				}

			?>
			</form>

  		</div>
	</div>

</body>
</html>