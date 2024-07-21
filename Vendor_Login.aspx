<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Vendor_Login.aspx.cs" Inherits="Vendor_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Vendor Login</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Bootstrap 5 CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css"
        integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous" />
    <!-- Custom CSS for animations -->
    <style>
        /* Gradient Background */
        .gradient-custom-2 {
            background: #fccb90;
            background: -webkit-linear-gradient(to right, #ee7724, #d8363a, #dd3675, #b44593);
            background: linear-gradient(to right, #ee7724, #d8363a, #dd3675, #b44593);
        }

        /* Login Form Height */
        @media (min-width: 768px) {
            .gradient-form {
                height: 100vh !important;
            }
        }

        /* Right Panel Border Radius */
        @media (min-width: 769px) {
            .gradient-custom-2 {
                border-top-right-radius: .3rem;
                border-bottom-right-radius: .3rem;
            }
        }

        /* Animation for card */
        .card {
            animation: fadeInUp 1s forwards;
        }

        @keyframes fadeInUp {
            from {
                opacity: 0;
                transform: translateY(20px);
            }

            to {
                opacity: 1;
                transform: translateY(0);
            }
        }
        .bg-light-gradient {
    /* Gradient Background */
    background: #fccb90; /* Fallback for older browsers */
    background: -webkit-linear-gradient(to right, #ee7724, #d8363a, #dd3675, #b44593); /* Chrome 10-25, Safari 5.1-6 */
    background: linear-gradient(to right, #ee7724, #d8363a, #dd3675, #b44593); /* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
}

    </style>
</head>
<body class="bg-light-gradient">
    <header class="bg-dark text-white py-3">
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <h1>Welcome to PeTi Shop - Vendor</h1>
                    <p>Login to access your account.</p>
                </div>
            </div>
        </div>
    </header>

    <form id="form1" runat="server" class="bg-light-gradient">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

        <section class="h-100 gradient-form bg-light-gradient" style="background-color: #eee;">
            <div class="container py-5 h-100 bg-light-gradient">
                <div class="row d-flex justify-content-center align-items-center h-100">
                    <div class="col-xl-10">
                        <div class="card rounded-3 text-black">
                            <div class="row g-0">
                                <div class="col-lg-6">
                                    <div class="card-body p-md-5 mx-md-4">

                                        <div class="text-center">
                                            <img src="ekshop.jpg" style="width: 185px; opacity: 1;" alt="logo" />
                                            <h4 class="mt-1 mb-5 pb-1">Vendor Login</h4>
                                        </div>

                                        <!-- Login Form -->
                                        <div class="form-outline mb-4">
                                            <asp:TextBox ID="txtUserName" runat="server" Placeholder="Enter Your Username "
                                                Width="300px" Height="40px" CssClass="form-control rounded" />
                                            <label class="form-label" for="txtUserName">Username</label>
                                        </div>

                                        <div class="form-outline mb-4">
                                            <asp:TextBox ID="txtPWD" runat="server" TextMode="Password"
                                                Placeholder="Enter Your Password" Width="300px" Height="40px"
                                                CssClass="form-control rounded" />
                                            <label class="form-label" for="txtPWD">Password</label>
                                        </div>

                                        <div class="text-center pt-1 mb-5 pb-1">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click"
                                                CssClass="btn btn-primary rounded" Width="100px" Height="40px" />
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </form>

    <!-- Animations -->
    <script>
        // JavaScript for additional animations
        document.addEventListener("DOMContentLoaded", function () {
            const card = document.querySelector('.card');
            card.classList.add('animate__animated', 'animate__fadeInUp');
        });
    </script>
    <!-- End of Animations -->
</body>
</html>
