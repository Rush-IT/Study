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

				//Массив названий таблиц
				$strName = "name";

				//Массив типов данных
				$strType = "type";

				//Массив Длин
				$strLenght = "lenght";

				//Массив Ключей
				$strAuto = "auto";

				//Названия столбцов
				$arr = ["Имя", "Тип", "Длинна", "A_I"];
				echo "<tr>";
				for($n = 0; $n<4; $n++)
					echo "<td>$arr[$n]</td>";
				echo "</tr>";

				//Названия столбцов и их значения
				$colums = mysqli_query($bd, "SHOW COLUMNS FROM ".$table);
				$Name = "value";
                echo "<tr>";
                //Название столбцов

                //Ячейки названий столбцов
				$textName = $strName."$number";
				echo "<td><input class='butt' type='text' name='$textName' /></td>";

				//Ячейки для типа данных
				$textName = $strType."$number";
				echo "<td><p><select class='butt' name='$textName'>
				<option>INT</option>
				<option>VARCHAR</option></td>";

				//Ячейки для длинны
				$textName = $strLenght."$number";
				echo "<td><input class='butt' type='text' name='$textName'/></td";
				echo "<td></td>";

				//Ячейка для ключа A_I
				$textName = $strAuto."$number";
				echo "<td><input class='butt' type='checkbox' name='$textName' /></td>";

                echo "</tr>";

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
					if($_POST[$strName."$number"]!="")
					{


						//Имя для запроса
						$textName = $strName."$number";
						$sqlValue .= $_POST["$textName"]." ";
						//Тип для запроса
						$textName = $strType."$number";
						$sqlValue .= $_POST["$textName"];

						if($_POST[$strType."$number"]!="INT")
						{
							//Длинна для запроса
							$textName = $strLenght."$number";
							$sqlValue .= "(".$_POST["$textName"].") ";
						}
						else if ($_POST[$strAuto."$number"]!="")
						{
							//Ключ для запроса
							$textName = $strAuto."$number";
							$sqlValue .= " AUTO_INCREMENT PRIMARY KEY";
						}
						$number++;
						$flag = true;
					}
					if($flag)
					{
						echo "ALTER TABLE `$table` ADD ".$sqlValue;
						$mysqli = new mysqli("localhost", "root", "123", $data);
						$mysqli->query("ALTER TABLE `$table` ADD ".$sqlValue);
						echo '<meta http-equiv = "Refresh" CONTENT="0; URL = /table.php">';
					}
				}



			?>
			</form>

  		</div>
	</div>

</body>
</html>