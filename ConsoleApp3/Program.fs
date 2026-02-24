// Задание 3: Вариант - 1
open System;

// Комплексное число кортеж (действительная часть, мнимая часть)
type Complex = int * int

// Основные операции
let addition (a1, b1) (a2, b2) = 
    (a1 + a2, b1 + b2) 

let subtraction (a1, b1) (a2, b2) = 
    (a1 - a2, b1 - b2) 

let multiplication (a1, b1) (a2, b2) = 
    (a1 * a2 - b1 * b2, a1 * b2 + b1 * a2) 

let division (a1, b1) (a2, b2) =
    let denominator = a2 * a2 + b2 * b2
    if denominator = 0 then 
       failwith "Деление на ноль невозможно"
    else 
       ((a1 * a2 + b1 * b2) / denominator, (b1 * a2 - a1 * b2) / denominator)

let power (a, b) n =
    if n < 0 then 
       failwith "Отрицательная степень невозможна"
    else if n = 0 then 
         (1, 0)  
    else
        let mutable result = (1, 0)  
        for i in 1..n do
            result <- multiplication result (a, b)
        result

// Вывод комплексного числа
let Print_Complex (a, b) =
    if b >= 0 then printfn "Результат вычислений: %d + %di" a b
    else printfn "Результат вычислений: %d - %di" a (-b)

// Проверка степени на корректность
let rec Check_degree() =
    let input = Console.ReadLine()
    let succes, n = Int32.TryParse(input)
    if succes && n >= 0 then
       n
    else
        printfn "Ошибка: Введенное число должно быть натуральным. Введите другое число: "
        Check_degree()

// Проверка числа на корректность
let rec Check_quantity() =
    let input = Console.ReadLine()
    let succes, n = Int32.TryParse(input)
    if succes then
       n
    else
        printfn "Ошибка: Введенное число должно быть целым. Введите другое число: "
        Check_quantity()

// Считывание комплексного числа от пользователя
let Read_Complex() =
    printfn "Введите действительную часть числа: "
    let real = Check_quantity()
    printfn "Введите мнимую часть числа: "
    let imaginary = Check_quantity()
    (real, imaginary)

[<EntryPoint>]
let main args =
    printfn "Введите два комплексных числа"
    let z1 = Read_Complex() 
    let z2 = Read_Complex() 
    printfn "Выберите операцию (1-5): 
             1) + 
             2) - 
             3) * 
             4) / 
             5) ^"
    let operation = int(Console.ReadLine())
    if operation = 1 then
       let result = addition z1 z2
       Print_Complex result
    else if operation = 2 then
       let result = subtraction z1 z2
       Print_Complex result
    else if operation = 3 then
         let result = multiplication z1 z2
         Print_Complex result
    else if operation = 4 then
         let result = division z1 z2
         Print_Complex result
    else if operation = 5 then
         printfn "Введите целую степень: "
         let n = Check_degree()
         let result = power z1 n
         Print_Complex result
    else
         printfn "Введите операцию 1-5"
    0