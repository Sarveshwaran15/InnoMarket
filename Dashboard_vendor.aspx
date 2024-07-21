<%@ Page Title="" Language="C#" MasterPageFile="~/Vendor.master" AutoEventWireup="true" CodeFile="Dashboard_vendor.aspx.cs" Inherits="Dashboard_vendor" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!--style>
        /* Custom styles */
        .custom-div {
            background-color: #8832dc; /* Light gray background */
            padding: 20px; /* Add some padding */
            border-radius: 10px; /* Rounded corners */
            box-shadow: 0px 0px 10px 0px rgb(20 116 158); /* Box shadow */
            color:darkgrey;
            font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
            font-size:100px;
            margin-right:1700px;
            margin-left:100px;
            
            padding-right:150px;
            border-radius:30px;
            
        }
         .container {

            width: 100%;
            margin-top:200px;
            overflow: hidden;
            gap:100px;/* Clearfix to contain floated children */
        }
         .box {
              border-radius: 10px; /* Rounded corners */
            box-shadow: 0px 0px 10px 0px rgb(20 116 158); /* Box shadow */
            color:azure;
            font-size:100px;
            font-family:'Brush Script MT';
            text-align:center;
            display: inline-block;
             background-color:green;
            width: 38%; /* Make each div take up 50% of the container width */
            float: inline-start; /* Float the divs to make them appear side by side */
            box-sizing: border-box; /* Include padding and border in the div's total width */
            padding: 20px;
            margin-bottom:10px;
            border: 1px solid #ccc;
            gap:100px;
            margin-right: 0;
        }
       .custom-div2{
           background-color: #8832dc; /* Light gray background */
            padding: 20px; /* Add some padding */
            border-radius: 10px; /* Rounded corners */
            box-shadow: 0px 0px 10px 0px rgb(20 116 158); /* Box shadow */
            color:darkgrey;
            font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
            font-size:100px;
            margin-top:5px;
            margin-left:1200px;
            margin-right:500px;
            border-radius:30px;
       }
       .h1{
           color:aliceblue;
       }
    </!--style-->
    <style>
    /* Custom styles */
    .content-background {
    background-color:#66A5AD;
}

    .custom-div {
      background-color: #f8f9fa;
      border: 1px solid #dee2e6;
      border-radius: 5px;
      padding: 10px;
      margin: 20px;
      transition: all 0.3s ease;
      padding-right:90px;
    }
    
    .custom-div:hover {
      transform: scale(1.05);
      box-shadow: 0px 0px 15px rgba(0, 0, 0, 0.1);
    }
    
    /* Colors */
    .first-div {
      background-color: #007bff;
      color: #fff;
    }
    
    .second-div {
      background-color: #28a745;
      color: #fff;
    }
  </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:Label ID="lblUsername" runat="server"></asp:Label>
     <div class="content-background">
             <div class="container-fluid">
                <h1 style ="animation-delay:inherit; color:aliceblue;">Seller Dashboard</h1> 
    <div class="row">
         <div class="col-md-4">
             


      <!-- First Div -->
      <div class=" custom-div first-div">
                                        Number of Products sold
                                    </h5> <p class="mb-2 fw-bold">
                                     <div id="displayDiv2"  runat="server">

                                     </p></div>
                                   
                                </div>
            </div>
         <div class="col-md-2">
                            
                        <div class="col custom-div second-div">
                                            Total Earnings
                                        </h5>
                                        <p class="mb-2 fw-bold"><div id="Div1"  runat="server">
                                            
                                        </p></div>
                                        
                               </div>
                        
                        <!-- Add other similar card elements as needed -->
                    </div>
                </div>
     <div class=" custom-div first-div">
                                        Number of products available
                                    </h5> <p class="mb-2 fw-bold">
                                     <div id="Div2"  runat="server">

                                     </p></div>
                                   
                                </div>
     <div class="col custom-div second-div">
                                            Amount to be settle
                                        </h5>
                                        <p class="mb-2 fw-bold"><div id="Div3"  runat="server">
                                            
                                        </p></div>
                                        
                               </div>
    <div class=" custom-div first-div">
                                        Number of products returned
                                    </h5> <p class="mb-2 fw-bold">
                                     <div id="Div4"  runat="server">

                                     </p></div>
                                   
                                </div>
            </div>
  
   </div>
          
            
            <div class="container">
        <h1 style="color:white;">Total Amount</h1>
        <div class="row">
            <div class="col-md-4">
                <canvas id="totalAmountChart" width="600" height="100" >
                   <asp:HiddenField ID="dataHiddenField" runat="server" />

                </canvas>
                
            </div>
        </div>
    </div>
    </div>
            

        </div>

    <!-- Bootstrap JS and jQuery (optional, for some Bootstrap components) -->
        <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/3.7.0/chart.min.js"></script>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script type="text/javascript"></script>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <script>
var data = JSON.parse(document.getElementById('<%= dataHiddenField.ClientID %>').value);

var labels = data.map(function (item) {
    return item[0] + ' - ' + item[1]; // Combining DateField and ProductName for label
});

var amounts = data.map(function (item) {
    return item[2]; // TotalAmount
});

var chartData = {
    labels: labels,
    datasets: [{
        label: 'Amounts',
        data: amounts,
        backgroundColor: [
            'rgba(75, 192, 192, 0.8)',
            'rgba(54, 162, 235, 0.8)',
            'rgba(255, 206, 86, 0.8)',
            'rgba(75, 192, 192, 0.8)',
            'rgba(153, 102, 255, 0.8)',
            'rgba(255, 159, 64, 0.8)',
            'rgba(255, 99, 132, 0.8)',
            'rgba(54, 162, 235, 0.8)',
            'rgba(255, 206, 86, 0.8)',
            'rgba(75, 192, 192, 0.8)',
        ],
        borderWidth: 2,
        borderColor: '#777',
        hoverBorderColor: '#000',
        hoverBorderWidth: 3
    }]
};

var ctx = document.getElementById('totalAmountChart').getContext('2d');
var advancedBarChart = new Chart(ctx, {
    type: 'bar', // Changed type to 'bar'
    data: chartData, // Corrected the data property here
    options: {
        layout: {
            padding: {
                left: 20,
                right: 20,
                top: 20,
                bottom: 20
            }
        },
        plugins: {
            datalabels: {
                display: false
            }
        },
        tooltips: {
            backgroundColor: '#000',
            bodyFontColor: '#fff',
            titleFontColor: '#fff',
            bodyFontSize: 10,
            xPadding:10,
            yPadding: 10,
            cornerRadius: 5,
            displayColors: false
        },
        legend: {
            display: false
        },
        animation: {
            duration: 2000,
            easing: 'easeOutBounce'
        },
        scales: {
            xAxes: [{
                gridLines: {
                    display: false
                },
                ticks: {
                    fontColor: '#333',
                    fontSize: 14,
                    padding: 10
                }
            }],
            yAxes: [{
                gridLines: {
                    color: 'rgba(0, 0, 0, 0.1)',
                    drawBorder: false
                },
                ticks: {
                    fontColor: '#333',
                    fontSize: 14,
                    padding: 10
                }
            }]
        }
    }
});
</script>



 <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/chartjs-plugin-datalabels"></script>


</asp:Content>

