# Flowiy
CodeReason based report preview.
We all know that Reporting and printing in WPF is painful
# Screenshot
<img src="https://raw.githubusercontent.com/mslaraba/flowiy/master/screenshot2.png"/>
# Use this code as first preview
```
<FlowDocument xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
              xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
              xmlns:xrd="clr-namespace:CodeReason.Reports.Document;assembly=CodeReason.Reports"
              PageHeight="28cm" PageWidth="20cm" ColumnWidth="20cm"   FontFamily="Times New Roman">
    <xrd:SectionReportHeader PageHeaderHeight="8" Padding="20,20,10,0" FontSize="12"  FontFamily="Times New Roman">
        <Paragraph>Yo</Paragraph>
        <Paragraph TextAlign="Center" FontWeight="Bold">RAPPORT D'EXPERTISES</Paragraph>
    </xrd:SectionReportHeader>
    
    <Section Padding="20,10,20,10" FontSize="12" BreakPageBefore="True">
        <Paragraph>            
        Hello yo yo 
        </Paragraph>
    </Section>
</FlowDocument>
```

