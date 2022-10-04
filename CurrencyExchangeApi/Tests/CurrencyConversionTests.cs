using CurrencyExchangeApi.Models;
using Xunit;

namespace CurrencyExchangeApi.Tests;

public class CurrencyConversionTests
{
    CurrencyConversion sourceModel;

    [Fact]
    public void CltoPersonalFundSingleLineWithNoTaxProducesOneOutputLine()
    {
        sourceModel = new CurrencyConversion
        {
            To = "EUR",
            From = "GBP",
            ConversionAmount = 10,
            ConversionResult = 12
        };

        //var result = new EmployeeExpenses(sourceModel);

        //result.Data.Count.Should().Be(1);
        //var actual = result.Data[0];
        //actual.TransDate.Should().Be(new DateOnly(2021, 12, 22));
        //actual.Invoice.Should().Be("04809BAE33604736AE65");
        //actual.DocumentDate.Should().Be(new DateOnly(2021, 11, 22));
        //actual.Voucher.Should().Be("0000001");
        //actual.AccountType.Should().Be("Vendor");
        //actual.AccountDisplayValue.Should().Be("HRM0016932");
        //actual.Text.Should().Be("November_Vendor not identified_Work travel");
        //actual.DebitAmount.Should().Be(0M);
        //actual.CreditAmount.Should().Be(2.58M);
        //actual.OffsetAccountType.Should().Be("Ledger");
        //actual.OffsetAccountDisplayValue.Should().Be("600108-329-D00214--");
        //actual.SalesTaxCode.Should().BeNull();
    }
}



