using System.Net;
using System.Net.Mail;
using System.Text;
using net_shop_back.Entities;
using net_shop_back.Models;
using net_shop_back.Services.Core;
using net_shop_back.Services.DI;

namespace net_shop_back.Services.Implementations;

[DefaultService]
public class DefaultMailService : IMailService
{
    private readonly IConfiguration _config;

    public DefaultMailService(IConfiguration config)
    {
        _config = config;
    }
    /*private readonly ICustomersService _customersService;

    public DefaultMailService(ICustomersService customersService)
    {
        _customersService = customersService;
    }
    */

    public Task SendMailAboutPurchaseAsync(string name, string phoneNumber, ProductMailModel[] products)
    {
        /*await _customersService.UpdateCustomerAsync(new Customer
        {
            Name = name,
            PhoneNumber = phoneNumber,
            Mail = mail
        });*/
        
        StringBuilder body = new StringBuilder();
    
        SmtpClient mySmtpClient = new SmtpClient("smtp.mail.ru", 25);

        mySmtpClient.UseDefaultCredentials = false;
        mySmtpClient.EnableSsl = true;
        mySmtpClient.Credentials = new NetworkCredential("ilyayaldinov@inbox.ru", "фывфыв");

        MailAddress from = new MailAddress("ilyayaldinov@inbox.ru", "www");
        MailAddress to = new MailAddress("ilyayaldinov@inbox.ru");
        MailMessage myMail = new MailMessage(from, to);

        myMail.Subject = "Подтверждение заказа";
        myMail.SubjectEncoding = Encoding.UTF8;

        body.Append("<h1>Подтверждение заказа</h1>");
        
        body.Append($"<b>Дата заказа: </b> {DateTime.Now}<br/>");
        body.Append($"<b>Имя заказчика: </b> {name}<br/>");
        body.Append($"<b>Номер телефона: </b> {phoneNumber}<br/>");
       
        body.Append(@"<table>");

        body.Append(@"<thead>
            <tr>
                <th>Название товара</th>
                <th>Количество</th>
                <th>Цена за единицу</th>
                <th>Итоговая стоимость</th>
            </tr>
            </thead>");
        body.Append("<tbody>");
        foreach (var product in products)
        {
            body.Append($@"<tr>
                    <td>{product.Name}</td>
                    <td>{product.Count}</td>
                    <td>{product.Price}</td>
                    <td>{product.Count * product.Price}</td>
                </tr>");
        }

        body.Append("</tbody>");
        body.Append("</table><br/><br/>");

        decimal finalPrice = 0;
        
        foreach (var product in products)
        {
            finalPrice += product.Count * product.Price;
        }

        body.Append($@"<tr>
            <td colspan=""3"" align=""right"">Итог:</td>
            <td>{finalPrice}</td>
            </tr>");
        
        myMail.Body = body.ToString();
        myMail.BodyEncoding = Encoding.UTF8;
        
        myMail.IsBodyHtml = true;

        mySmtpClient.Send(myMail);
        
        return Task.CompletedTask;
    }

    public Task SendMailAboutCallAsync(string phoneNumber)
    {
        StringBuilder body = new StringBuilder();

        SmtpClient mySmtpClient = new SmtpClient("smtp.mail.ru", 25);

        mySmtpClient.UseDefaultCredentials = false;
        mySmtpClient.EnableSsl = true;
        mySmtpClient.Credentials = new NetworkCredential("ilyayaldinov@inbox.ru", "фывфыв");

        MailAddress from = new MailAddress("ilyayaldinov@inbox.ru", "www");
        MailAddress to = new MailAddress("ilyayaldinov@inbox.ru");
        MailMessage myMail = new MailMessage(from, to);

        myMail.Subject = "Просьба перезвонить";
        myMail.SubjectEncoding = Encoding.UTF8;

        body.Append($"<h1>Пользователь с номером {phoneNumber} просил перезвонить.</h1>");
        
        myMail.Body = body.ToString();
        myMail.BodyEncoding = Encoding.UTF8;
            
        myMail.IsBodyHtml = true;

        mySmtpClient.Send(myMail);
        
        return Task.CompletedTask;
    }
}