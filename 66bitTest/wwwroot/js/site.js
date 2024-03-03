// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

/*import { error } from "jquery";*/

/*import { signalR } from "../lib/microsoft/signalr/dist/browser/signalr";*/

// Write your JavaScript code.
//$(() => {
//    LoadProdData();

//    var connection = new signalR.HubConnectionBuilder().withUrl("/hub66").build();
//    connection.start();
//    connection.on("LoadProducts", function () {
//        LoadProdData();
//    })

//    LoadProdData();

//    function LoadProdData() {
//        var tr = '';

//        $.ajax({
//            url: '/Catalog/GetProducts',
//            method: 'GET',
//            success: (result) => {
//                $.each(result, (k, v) => {
//                    tr += `<tr>
//                        <td>${v.FirstName}</td>
//                        <td>${v.SecondName}</td>
//                        <td>${v.Gender}</td>
//                        <td>${v.BirthDate}</td>
//                        <td>${v.Country}</td>
//                        <td>${v.Team.Title}</td>
//                        <td>
//                            <a href='../Catalog/Edit?id=${v.Id}'>Edit</a>
//                            <a href='../Catalog/Details?id=${v.Id}'>Details</a>
//                            <a href='../Catalog/Delete?id=${v.Id}'>Delete</a>
//                        </td>
//                    </tr>`
//                })
//                $("#tableBody").html(tr);
//            },
//            error: (error) => {
//                console.log(error)
//            }
//        });
//    }
//})



//$(function () {
//    connection.start().then(function () {
//        alert('Connected to hub66');
//		InvokeProducts();
//    }).catch(function (err) {
//        return console.error(err.toString());
//    });
//});

//function InvokeProducts() {
//	connection.invoke("Send").catch(function (err) {
//		return console.error(err.toString());
//	});
//}