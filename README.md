# Pdf Generator


## MultiPdfGeneration
This is an example project, on how you can use the Pdf generator, to generate a diploma.

## PdfGenerator
This is the class library you may want to reference in your project.

## PrintPageEditor

It is a Windows Forms application, to create *Printings xml* files, which can be processed by the Pdf Generator.
There is also a Curriculum vitae generator that is "hidden" in the application.

The *Printings xml* file can contain the following commands:

Print a line:
```
<PrintLine color="Yellow" x="605" y="103" x2="652" y2="127" line_width="1" />
```

Print an ellipse:
```
<PrintEllipse color="Yellow" x="510" y="36" width="103" height="91" line_width="1" fill="True" />
```

Print a rectangle:
```
<PrintRectangle color="Green" x="0" y="367" width="953" height="462" line_width="2" fill="True" />
```

Print a text:
```
<PrintText text="Curriculum vitæ" x="10" y="5" font_name="Comic Sans MS" font_style="bold" font_size="26" color="Black" />
```

Print an image:
```
<PrintImage image_filename=".\Resources\me.png" x="550" y="80" width="125" height="170" fixed_location="true" />
```

This is a valid *Printings xml* file:
```
<?xml version="1.0" encoding="utf-8" ?>
<Printings>
	<PrintText text="Curriculum vitæ" x="10" y="5" font_name="Comic Sans MS" font_style="bold" font_size="26" color="Black" />
</Printings>
```

This is how you can print out a *Printings xml* file into a pdf file:
```
var printingRulesFilePath = @".\Resources\Printings.xml";
var pdfPrinter = new PdfPrinter();
pdfPrinter.Print(@"C:\Pdf\Result.pdf", printingRulesFilePath);
```

You can create templates also, where you can replace the content of the result pdf:
```
var replaceables = new Dictionary<string, string>
{
	{ "@Name", nameToInsert },
	{ "@Position", position}" }
};
var printOutputPath = $".\\{position}. {nameAndPosition[0]}.pdf";
pdfPrinter.Print(printOutputPath, printingRulesFilePath, replaceables);
```

For more details, please check the *MultiPdfGeneration Program.cs* or the *PrintPageEditor MainForm.cs tsmiCurriculumVitæ_Click event* about templates.