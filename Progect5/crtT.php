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
				$number = file_get_contents('number.txt');
				echo "<table border='1'> <tr>";

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

				//Вывод строк для ввода данных
				for($n=1; $n<=$number;$n++)
				{
					echo "<tr>";

					//Ячейки названий столбцов
					$textName = $strName."$n";
					echo "<td><input class='butt' type='text' name='$textName' /></td>";

					//Ячейки для типа данных
					$textName = $strType."$n";
					echo "<td><p><select class='butt' name='$textName'>
					<option>INT</option>
					<option>VARCHAR</option></td>";

					//Ячейки для длинны
					$textName = $strLenght."$n";
					echo "<td><input class='butt' type='text' name='$textName'/></td";
					echo "<td></td>";

					//Ячейка для ключа A_I
					$textName = $strAuto."$n";
					echo "<td><input class='butt' type='checkbox' name='$textName' /></td>";
					echo "</tr>";
				}
				echo "</tr></table>";
				echo "<p><input class='butt2' type='submit' name='name' value='Создать' /></p>";

				//Создание таблицы
				if($_POST['name1'])
				{
					$sqlValue = "";
					$flag = false;
					for($n=1; $n<=$number;$n++)
					{
						if($_POST[$strName."$n"]!="")
						{
							if($flag)
							{
								$sqlValue.=', ';
							}

							//Имя для запроса
							$textName = $strName."$n";
							$sqlValue .= $_POST["$textName"]." ";

							//Тип для запроса
							$textName = $strType."$n";
							$sqlValue .= $_POST["$textName"];

							if($_POST[$strType."$n"]!="INT")
							{
								//Длинна для запроса
								$textName = $strLenght."$n";
								$sqlValue .= "(".$_POST["$textName"].") ";
							}

							else if ($_POST[$strAuto."$n"]!="")
							{
								//Ключ для запроса
								$textName = $strAuto."$n";
								$sqlValue .= " AUTO_INCREMENT PRIMARY KEY";
							}

							$flag = true;
						}
					}
					if($flag)
					{
						//echo "CREATE TABLE `$table` (".$sqlValue.")";
						$mysqli = new mysqli("localhost", "root", "123", $data);
						$mysqli->query("CREATE TABLE `$table` (".$sqlValue.")");
						echo '<meta http-equiv = "Refresh" CONTENT="0; URL = /1.php">';
					}
				}

			?>
			</form>

  		</div>
	</div>

</body>
</html>