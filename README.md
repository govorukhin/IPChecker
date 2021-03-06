# IPChecker
Решение тестового задания на определение доступности камер в сети.

#### Описание работы программы:
В программу вносятся ip адреса(либо имена хостов) и uri ресурсов на них. Каждый ip адрес пингуется. В случае положительного отклика, на соответствующий uri посылается get-запрос. Графический интерфейс отображает результаты операций. (Почему бы не обойтись только get-запросами? - потому что этого требовало задание)


#### Реализовано:
* Внесение адресов: вручную, загрузкой из файла, генерацией IP адресов из заданного интервала. В т.ч. и ipv6.
* Устойчивость к ошибкам ввода начальных данных.
* Проверка адресов ping запросами.
* Доступным адресам посылаются get-запросы.
* Все результаты отображаются графическим интерфейсом.
* Обработка адресов происходит асинхронно. Т.е. для проверки следующего ip не нужно ждать завершения проверки предыдущего. А также графический интерфейс в процессе проверки не зависает.
* Возможность отмены выполняющейся проверки.

#### Кратко о структуре программы:
Графический интерфейс сделан в виде двух страниц(userControl-ов, на форме): для этапа редактирования и этапа проверки. Страницы ничего друг о друге не знают и у каждой свои инструменты. Потому что если бы всё располагалось на одной странице, пришлось бы вводить блокировку кнопок не относящихся к текущему этапу.

Взаимодействие страниц и рабочих классов, задаётся в presenter-ах(шаблон MVP). Третий presenter отвечает за переключение страниц и передачу списка адресов из одной страницы в другую.

Проверка адресов реализована с использованием Task-ов. 
Чтобы результаты отображались по ходу, а не после завершения проверки всех адресов, обработка устроена следующим образом:
Обработка каждого адреса осуществляется своей цепочкой задач, в ходе которой происходит запись результатов в соответствующие поля bindingList. А изменения в  bindingList тут-же отображаются в datagridView(которую и видит пользователь).
А task, в ходе которого запускаются цепочки задач, не вникает в результаты обработки и не выдаёт их. Его задача сообщать графическому интерфейсу: запущен ли процесс проверки, а также отписываться о количестве завершённых цепочек.


