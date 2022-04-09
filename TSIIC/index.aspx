<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TSIIC.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<!doctype html>
<html>

<head>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<title>TSIIC -Dashboard </title>
<link rel='dns-prefetch' href='//fonts.googleapis.com' />
<link rel='dns-prefetch' href='//s.w.org' />
		<script type="text/javascript">
		    window._wpemojiSettings = { "baseUrl": "https:\/\/s.w.org\/images\/core\/emoji\/11\/72x72\/", "ext": ".png", "svgUrl": "https:\/\/s.w.org\/images\/core\/emoji\/11\/svg\/", "svgExt": ".svg", "source": { "concatemoji": "https:\/\/www.apiic.in\/wp-includes\/js\/wp-emoji-release.min.js?ver=4.9.15"} };
		    !function (a, b, c) { function d(a, b) { var c = String.fromCharCode; l.clearRect(0, 0, k.width, k.height), l.fillText(c.apply(this, a), 0, 0); var d = k.toDataURL(); l.clearRect(0, 0, k.width, k.height), l.fillText(c.apply(this, b), 0, 0); var e = k.toDataURL(); return d === e } function e(a) { var b; if (!l || !l.fillText) return !1; switch (l.textBaseline = "top", l.font = "600 32px Arial", a) { case "flag": return !(b = d([55356, 56826, 55356, 56819], [55356, 56826, 8203, 55356, 56819])) && (b = d([55356, 57332, 56128, 56423, 56128, 56418, 56128, 56421, 56128, 56430, 56128, 56423, 56128, 56447], [55356, 57332, 8203, 56128, 56423, 8203, 56128, 56418, 8203, 56128, 56421, 8203, 56128, 56430, 8203, 56128, 56423, 8203, 56128, 56447]), !b); case "emoji": return b = d([55358, 56760, 9792, 65039], [55358, 56760, 8203, 9792, 65039]), !b } return !1 } function f(a) { var c = b.createElement("script"); c.src = a, c.defer = c.type = "text/javascript", b.getElementsByTagName("head")[0].appendChild(c) } var g, h, i, j, k = b.createElement("canvas"), l = k.getContext && k.getContext("2d"); for (j = Array("flag", "emoji"), c.supports = { everything: !0, everythingExceptFlag: !0 }, i = 0; i < j.length; i++) c.supports[j[i]] = e(j[i]), c.supports.everything = c.supports.everything && c.supports[j[i]], "flag" !== j[i] && (c.supports.everythingExceptFlag = c.supports.everythingExceptFlag && c.supports[j[i]]); c.supports.everythingExceptFlag = c.supports.everythingExceptFlag && !c.supports.flag, c.DOMReady = !1, c.readyCallback = function () { c.DOMReady = !0 }, c.supports.everything || (h = function () { c.readyCallback() }, b.addEventListener ? (b.addEventListener("DOMContentLoaded", h, !1), a.addEventListener("load", h, !1)) : (a.attachEvent("onload", h), b.attachEvent("onreadystatechange", function () { "complete" === b.readyState && c.readyCallback() })), g = c.source || {}, g.concatemoji ? f(g.concatemoji) : g.wpemoji && g.twemoji && (f(g.twemoji), f(g.wpemoji))) } (window, document, window._wpemojiSettings);
		</script>
		<style type="text/css">
img.wp-smiley,
img.emoji {
	display: inline !important;
	border: none !important;
	box-shadow: none !important;
	height: 1em !important;
	width: 1em !important;
	margin: 0 .07em !important;
	vertical-align: -0.1em !important;
	background: none !important;
	padding: 0 !important;
}
</style>

<script src="https://code.jquery.com/jquery-3.1.1.min.js"></script>
<script src="https://code.highcharts.com/highcharts.js"></script>
<script src="https://code.highcharts.com/modules/exporting.js"></script>
<script src="https://code.highcharts.com/modules/export-data.js"></script>
<script src="https://code.highcharts.com/modules/accessibility.js"></script>
    <link href="css1/dataTables.bootstrap4.min.css" rel="stylesheet" type="text/css" />
    <script src="css1/jquery.dataTables.min.js" type="text/javascript"></script>


    <script src="css1/dataTables.bootstrap4.min.js" type="text/javascript"></script>

<style type="text/css">


.highcharts-figure, .highcharts-data-table table {
    min-width: 320px; 
    max-width: 660px;
    margin: 1em auto;
}

.highcharts-data-table table {
	font-family: Verdana, sans-serif;
	border-collapse: collapse;
	border: 1px solid #EBEBEB;
	margin: 10px auto;
	text-align: center;
	width: 100%;
	max-width: 500px;
}
.highcharts-data-table caption {
    padding: 1em 0;
    font-size: 1.2em;
    color: #555;
}
.highcharts-data-table th {
	font-weight: 600;
    padding: 0.5em;
}
.highcharts-data-table td, .highcharts-data-table th, .highcharts-data-table caption {
    padding: 0.5em;
}
.highcharts-data-table thead tr, .highcharts-data-table tr:nth-child(even) {
    background: #f8f8f8;
}
.highcharts-data-table tr:hover {
    background: #f1f7ff;
}
</style>
 
<link href="http://tracgis.telangana.gov.in/TIS/TISNEW/tsiic/css1/sb-admin-2.min.css" rel="Stylesheet" />

<link rel='stylesheet' id='contact-form-7-css'  href="Styles/styles.css" type='text/css' media='all' />
<%--<link rel='stylesheet' id='twentythirteen-fonts-css'  href='//fonts.googleapis.com/css?family=Source+Sans+Pro%3A300%2C400%2C700%2C300italic%2C400italic%2C700italic%7CBitter%3A400%2C700&#038;subset=latin%2Clatin-ext' type='text/css' media='all' />
<link rel='stylesheet' id='genericons-css'  href='https://www.apiic.in/wp-content/themes/apindus/genericons/genericons.css?ver=3.03' type='text/css' media='all' />
<link rel='stylesheet' id='twentythirteen-style-css'  href='https://www.apiic.in/wp-content/themes/apindus/style.css?ver=2013-07-18' type='text/css' media='all' />--%>
<!--[if lt IE 9]>
<link rel='stylesheet' id='twentythirteen-ie-css'  href='https://www.apiic.in/wp-content/themes/apindus/css/ie.css?ver=2013-07-18' type='text/css' media='all' />
<![endif]-->
<script type='text/javascript' src='https://www.apiic.in/wp-includes/js/jquery/jquery.js?ver=1.12.4'></script>
<script type='text/javascript' src='https://www.apiic.in/wp-includes/js/jquery/jquery-migrate.min.js?ver=1.4.1'></script>
<link rel='https://api.w.org/' href='https://www.apiic.in/wp-json/' />
<link rel="EditURI" type="application/rsd+xml" title="RSD" href="https://www.apiic.in/xmlrpc.php?rsd" />
<link rel="wlwmanifest" type="application/wlwmanifest+xml" href="https://www.apiic.in/wp-includes/wlwmanifest.xml" /> 
<meta name="generator" content="WordPress 4.9.15" />
<link rel="canonical" href="https://www.apiic.in/" />
<link rel='shortlink' href='https://www.apiic.in/' />
<link rel="alternate" type="application/json+oembed" href="https://www.apiic.in/wp-json/oembed/1.0/embed?url=https%3A%2F%2Fwww.apiic.in%2F" />
<link rel="alternate" type="text/xml+oembed" href="https://www.apiic.in/wp-json/oembed/1.0/embed?url=https%3A%2F%2Fwww.apiic.in%2F&#038;format=xml" />
		<style type="text/css">.recentcomments a{display:inline !important;padding:0 !important;margin:0 !important;}</style>
		<link rel="pingback" href="https://www.apiic.in/xmlrpc.php">
<link href="https://www.apiic.in/wp-content/themes/apindus/css/font-awesome.css" rel="stylesheet" type="text/css">
<link href="https://www.apiic.in/wp-content/themes/apindus/css/icon-font.css" rel="stylesheet" type="text/css">
<link href="https://www.apiic.in/wp-content/themes/apindus/css/bootstrap.css" rel="stylesheet" type="text/css">
<link href="https://www.apiic.in/wp-content/themes/apindus/css/style.css" rel="stylesheet" type="text/css">
<link href="https://www.apiic.in/wp-content/themes/apindus/css/owl.carousel.css" rel="stylesheet" type="text/css">
<link href="https://www.apiic.in/wp-content/themes/apindus/css/responsive.css" rel="stylesheet" type="text/css">
<link rel="stylesheet" type="text/css" href="https://www.apiic.in/wp-content/themes/apindus/css/demo.css" />
<link rel="stylesheet" type="text/css" href="https://www.apiic.in/wp-content/themes/apindus/css/common.css" />
<link rel="stylesheet" type="text/css" href="https://www.apiic.in/wp-content/themes/apindus/css/style2.css" />
<link href='http://fonts.googleapis.com/css?family=Open+Sans:300,700' rel='stylesheet' type='text/css' />



<style type="text/css">


/*gridview*/
.table table  tbody  tr  td a ,
.table table  tbody  tr  td  span {
position: relative;
float: left;
padding: 6px 12px;
margin-left: -1px;
line-height: 1.42857143;
color: #337ab7;
text-decoration: none;
background-color: #fff;
border: 1px solid #ddd;
}

.table table > tbody > tr > td > span {
z-index: 3;
color: #fff;
cursor: default;
background-color: #337ab7;
border-color: #337ab7;
}

.table table > tbody > tr > td:first-child > a,
.table table > tbody > tr > td:first-child > span {
margin-left: 0;
border-top-left-radius: 4px;
border-bottom-left-radius: 4px;
}

.table table > tbody > tr > td:last-child > a,
.table table > tbody > tr > td:last-child > span {
border-top-right-radius: 4px;
border-bottom-right-radius: 4px;
}

.table table > tbody > tr > td > a:hover,
.table   table > tbody > tr > td > span:hover,
.table table > tbody > tr > td > a:focus,
.table table > tbody > tr > td > span:focus {
z-index: 2;
color: #23527c;
background-color: #eee;
border-color: #ddd;
}
/*end gridview */


</style>
</head>
<body>
<form runat="server">
<header class="bg-img">
	<div class="container">  
		<div class="upper-header">   
        	<div class="contact-strip" style="width:10%; float:left;"> 
				<div class="phone-no">
					<img src="https://www.telangana.gov.in/Style%20Library/GoT/Content/img/logo.png" alt="cardinal">
				</div>
                </div><!-- /contact-strip -->
            <div style="text-align:center; float:left; width:80%"> 
            <h2 style="font-size:26px; margin-top:6px; margin-bottom:0px; color:#003991;">Telangana State Industrial Infrastructure Corporation</h2>
            <span style="font-size:16px">( A GOVT. OF TELANGANA STATE UNDERTAKING )</span>
            </div>
		
				 
			

                <div class="logo" style="width:10%; float:left;"><a href="https://www.apiic.in/"><img src="https://tsiic.telangana.gov.in/images/logo.png" alt="cardinal"></a></div>
			
		</div><!-- /upper-header -->
		<div class="navbar-header">
				<button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
					<span class="sr-only">Toggle navigation</span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
				</button>				
			</div>
	</div>
</header>

 <div id="navbar" class="navbar">
				<%--<nav id="site-navigation" class="navigation main-navigation" role="navigation">
					<button class="menu-toggle">Menu</button>
					<a class="screen-reader-text skip-link" href="#content" title="Skip to content">Skip to content</a>
								 
				</nav> --%>
            

     </div>

  


  <div class="container-fluid">
        <style>
 .no-js #loader { display: none;  }<br />
.js #loader { display: block; position: absolute; left: 100px; top: 0; }<br />
.se-pre-con {<br />
	position: fixed;<br />
	left: 0px;<br />
	top: 0px;<br />
	width: 100%;<br />
	height: 100%;<br />
	z-index: 9999;<br />
	background: url(https://www.apiic.in/wp-content/uploads/2017/08/image-loader.gif) center no-repeat #fff;<br />
}
<br />

</style>
<p>&nbsp;</p>
<p>&nbsp;</p>


<p>&nbsp;</p>
<%--<div style="height: 40px; line-height: 13px; background: linear-gradient(to right, rgba(240,240,14,1) 0%, rgba(240,240,14,1) 7%, rgba(245,250,173,1) 91%, rgba(245,250,173,1) 100%); filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#f0f00e', endColorstr='#f5faad', GradientType=1 ); display: flex; border-radius: 25px;">
<div style="min-width: 190px; background: #5eebff; border-radius: 25px 0 0 25px; text-align: center;">
<p style="position: relative; top: 1px;"><a style="font-size: 15px; font-weight: bold; color: blue; padding: 5px; line-height: 1.2;" href="https://www.apiic.in/wp-content/uploads/2019/03/Key-considerations-for-Appraisal-of-DPR-and-Checklist-of-DPR-Components.pdf" target="_blank" rel="noopener">Components of Detailed Project Report  </a></p>
</div>
<p>&nbsp;<br />
<marquee behavior="scroll" direction="left" onmouseover="this.stop();" onmouseout="this.start();"  scrollamount="8" style="margin-center: 0px;" ></p>
<div style="display: inline-flex; position: relative; top: -10px;">
<p><a href="https://www.apiic.in/wp-content/uploads/2020/04/EOI-1.pdf" target="_blank"; style="font-size:15px; font-weight:bold; color:blue; padding:5px; margin-right: 40px;"><img src="https://www.apiic.in/wp-content/uploads/2017/01/new_blink.gif">APIIC Invites EoI from Consultancy Firms to provide two Middle Level In-House Consultants on retainership basis who are having hands on experience with industries related matters.</a></p>
<p><!--
  <a href="https://www.apiic.in/wp-content/uploads/2020/03/APIIC-EOI.pdf" target="_blank"; style="font-size:15px; font-weight:bold; color:blue; padding:5px; margin-right: 40px;">APIIC Invites EoI for arranging equity and debt funds for the proposed 3.0 MT integrated steel plant being established by *M/s AP High Grade Steels Limited* (A fully owned entity of GoAP) in YSR Kadapa District.Last date for submission of bids is 10.04.2020.</a><a href="https://www.apiic.in/wp-content/uploads/2020/04/Amendments-to-EOI_V1.docx" target="_blank"; style="font-size:15px; font-weight:bold; color:blue; padding:5px; margin-right: 40px;">Corrigendum to EOI of arranging equity and debt.</a>


<a style="font-size: 15px; font-weight: bold; color: blue; padding: 5px; margin-right: 40px;" target="_blank" rel="noopener"><img src="https://www.apiic.in/wp-content/uploads/2017/01/new_blink.gif"/>APIIC is not engaging any outsourcing Agency services for manpower supply. Outsourcing will be done by only APCOS as per G.O. Plese do not believe fake news circulated in social media.</a>



<a href="https://www.apiic.in/wp-content/uploads/2019/10/tender-doc-Mallvalli.pdf" target="_blank"; style="font-size:15px; font-weight:bold; color:blue; padding:5px; margin-right: 40px;"><img src="https://www.apiic.in/wp-content/uploads/2017/01/new_blink.gif"> Expression of Interest Called For Engaging an Integrated Value Added Service Provider for Core Processing Facility(CPC) at Mega Food Park, Mallavalli (M), Krishna (D), Andhra Pradesh</a>

--></p>
<p><a style="font-size: 15px; font-weight: bold; color: blue; padding: 5px; margin-right: 40px;"><img src="" />Applicants shall be liable to pay land cost prevailing at the time of provisional allotment , but not at the rate on the date of application submission.</a></p>
<p><!--

<a style="font-size:15px; font-weight:bold; color:blue; padding:5px; margin-right: 40px;"><img src="https://www.apiic.in/wp-content/uploads/2017/01/new_blink.gif">APIIC Application server are under maintance from 6.09.2019  at 9.00 PM to 7.09.2019 at 9.00 AM During this period Applications are not available for access</a>



<a style="font-size: 15px; font-weight: bold; color: blue; padding: 5px; margin-right: 40px;" href="https://www.apiic.in/wp-content/uploads/2019/06/General-Reform-Summary.pdf" target="_blank" rel="noopener"><img src="" />Generic Reform.</a> --></p>
<p><!--

<a href="https://www.apiic.in/wp-content/uploads/2019/02/RFP_Housing-at-IP-Ammavaripalli_21st-Feb-2019.pdf" target="_blank"; style="font-size:15px; font-weight:bold; color:blue; padding:5px; margin-right: 40px;"><img src="https://www.apiic.in/wp-content/uploads/2017/01/new_blink.gif">Request for Proposal for Development of Housing on 10 Acre Land at Ammavaripalli Industrial Park at Erramanchi (V), Penugonda (M), Ananthapur District, Andhra Pradesh near Kia Motors India Plant</a>



<a style="font-size: 15px; font-weight: bold; color: blue; padding: 5px; margin-right: 40px;" target="_blank" rel="noopener"><img src="https://www.apiic.in/wp-content/uploads/2017/01/new_blink.gif" />It is our pleasure to inform you that our Head Office is going to function at Our APIIC Towers,IT Park,Manglagiri,Guntur from 11.02.2019</a>
--><br />
<!--

<a href="http://ambedkarsmruthivanam.in/" target="_blank"; style="font-size:15px; font-weight:bold; color:blue; padding:5px; letter-spacing:1px; margin-right: 40px;"><img src="https://www.apiic.in/wp-content/uploads/2017/01/new_blink.gif">&nbsp;Dr. B.R. Ambedkar Smruthi Vanam Project, Voting for design preference is closed at 3:00pm on 15 Dec 2017 &nbsp;</a>

<a href="https://www.apiic.in/wp-content/uploads/2018/04/RFP_Affordable-Housing_3-April-2018.pdf" target="_blank"; style="font-size:15px; font-weight:bold; color:blue; padding:5px; letter-spacing:1px; margin-right: 40px;"><img src="https://www.apiic.in/wp-content/uploads/2017/01/new_blink.gif">&nbsp;RFP Document: Invitation of Applications for Allotment of 10 Acres land near Tirupati Airport for  Development of Affordable Housing Project&nbsp;</a>

<a href="https://www.apiic.in/wp-content/uploads/2018/04/Response-to-Queries.pdf" target="_blank"; style="font-size:15px; font-weight:bold; color:blue; padding:5px; letter-spacing:1px; margin-right: 40px;"><img src="https://www.apiic.in/wp-content/uploads/2017/01/new_blink.gif">&nbsp;Response to Queries&nbsp;</a>

<a href="https://www.apiic.in/wp-content/uploads/2018/04/Corrigendum-1.pdf" target="_blank"; style="font-size:15px; font-weight:bold; color:blue; padding:5px; letter-spacing:1px; margin-right: 40px;"><img src="https://www.apiic.in/wp-content/uploads/2017/01/new_blink.gif">&nbsp;Corrigendum-1 (Key Dates of Bidding Process)&nbsp;</a>

<a href="https://www.apiic.in/wp-content/uploads/2018/06/Corrigendum-2.pdf" target="_blank"; style="font-size:15px; font-weight:bold; color:blue; padding:5px; letter-spacing:1px; margin-right: 40px;"><img src="https://www.apiic.in/wp-content/uploads/2017/01/new_blink.gif">&nbsp;Corrigendum-II&nbsp;</a>

--></p>
<p><a style="font-size: 15px; font-weight: bold; color: blue; padding: 5px; margin-right: 40px;" href="http://103.210.73.21/APIIC-LANDBANK" target="_blank" rel="noopener"><img src=""/> APIIC GIS for Industrial Land Enquiry (AGILE). </a></p>
<p><!--

<a href="https://www.apiic.in/downloads_tenders.html" target="_blank"; style="font-size:15px; font-weight:bold; color:blue; padding:5px; letter-spacing:1px; margin-right: 40px;"><img src="https://www.apiic.in/wp-content/uploads/2017/01/new_blink.gif">&nbsp;Invitation For Development of Global In-House Centers (GIC) Under PPP Mode As Per The AP GIC Policy&nbsp;</a>

<a href="https://www.apiic.in/wp-content/uploads/2018/11/rpf.pdf" target="_blank"; style="font-size:15px; font-weight:bold; color:blue; padding:5px; margin-right: 40px;"><img src="https://www.apiic.in/wp-content/uploads/2017/01/new_blink.gif">Request for Proposal For Post implementation support, maintenance and enhancements for Oracle E-Business Suite (R12) and its applications & Design, development and maintenance of Land Alienation/ Acquisition Process Application&nbsp;</a>

<a href="https://www.apiic.in/wp-content/uploads/2018/11/RFP-GIS.pdf" target="_blank"; style="font-size:15px; font-weight:bold; color:blue; padding:5px; margin-right: 40px;"><img src="https://www.apiic.in/wp-content/uploads/2017/01/new_blink.gif">&nbsp;Request for Proposal For Post Implementation maintenance and enhancement of APIIC GIS FOR INDUSTRIAL LAND ENQUIRY (AGILE)  Dynamic WEB GIS Application and Integration with Oracle EBS (R12)&nbsp;</a>

<a href="https://www.apiic.in/wp-content/uploads/2018/11/Expression-of-Interest-Commercial-Development-at-Ammavaripalli_23rd-November-2018.pdf" target="_blank"; style="font-size:15px; font-weight:bold; color:blue; padding:5px; margin-right: 40px;"><img src="https://www.apiic.in/wp-content/uploads/2017/01/new_blink.gif">&nbsp;Request for Expression of Interest for Commercial Development on 11 acre Land at Ammavaripalli Industrial Park at Erramanchi (V), Penugonda (M),Ananthapur (D), Andhra Pradesh</a>



<a style="font-size: 15px; font-weight: bold; color: blue; padding: 5px; margin-right: 40px;"><img src="https://www.apiic.in/wp-content/uploads/2017/01/new_blink.gif" /> Payment by DD/CHEQUE is no longer available. Entrepreneurs are requested to pay through online mode only. </a>

<a style="font-size: 15px; font-weight: bold; color: blue; padding: 5px; letter-spacing: 1px; margin-right: 40px;" href="https://kpi.apiic.in:8443/MSME" target="_blank" rel="noopener"><img src="" />  APIIC MSME Portal.  </a>

<a style="font-size: 15px; font-weight: bold; color: blue; padding: 5px; letter-spacing: 1px; margin-right: 40px;" href="http://www.apiic.in/wp-content/uploads/2018/11/MSME-Componenet-for-Detailed-Project-Report.pdf" target="_blank" rel="noopener"><img src="" />  MSME - Component for Detailed Project Report.  </a> --></p>
</div>
<p></marquee><br />
&nbsp;</p>
<div style="min-width: 300px; text-align: center; background: #5eebff; border-radius: 0 25px 25px 0;">
<p style="position: relative; top: 10px;"><a style="font-size: 15px; font-weight: bold; color: blue; line-height: 1.2;" href="https://kpi.apiic.in:8443/OnlineEnquiry" target="_blank" rel="noopener">Online Enquiry</a> | <b><span style="color: red;">GSTIN :37AABCA9029K1ZG</span></b></p>
</div>
</div>--%>
<div class="clearfix"></div>
<!--<p>


<div class="col-sm-12 text-center" style="margin-top:10px;"><b>For information on land enquiry: 86323281850 | For enquiry on DPR  0863-2381857</b></div>


</p>-->
<div class="row">

<div class="col-md-12 col-sm-12">
<%--<h3 class="sub-head">Andhra Pradesh</h3>
<p style="text-align: justify;">is one of the 28 states of India, situated on the country’s southeastern coast. The state is the eighth largest state in India covering an area of 160,205 km2(61,855 sq mi).As per 2011 census of India, the state is tenth largest by population with 49,386,799 inhabitants.</p>
<p style="text-align: justify;">The new capital city of Andhra pradesh is proposed in Guntur District, north of Guntur City and will be developed under Capital Region Development Authority. In accordance with the Andhra Pradesh Reorganisation Act, 2014, Hyderabad will remain the de jure capital of both Andhra Pradesh and Telangana states for a period of time not exceeding 10 years.</p>
--%>
 <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered table-hover table-responsive" OnPageIndexChanging="OnPageIndexChanging" OnRowCommand="grdCustomPagging_RowCommand"  runat="server" PageSize="10"  AutoGenerateColumns="false"  AllowPaging="true" >
 
   <Columns>
          <asp:BoundField DataField="Park_Name" HeaderText="Park Name">
                    <ItemStyle Font-Size="Medium" />
                </asp:BoundField>              
                <asp:BoundField DataField="Park_Name" HeaderText="Name">
                    <ItemStyle Font-Size="Medium" />
                </asp:BoundField>
       <asp:TemplateField HeaderText="Action">
        <ItemTemplate>
       <asp:LinkButton runat="server" ID="lnkView" CommandArgument='<%#Eval("Park_Name") %>'
         CommandName="VIEW">Insert Row</asp:LinkButton>
         </ItemTemplate>
       </asp:TemplateField>
   </Columns>
          </asp:GridView>


</div>

</div>
 </div>

</form>

<footer>
 
  <div class="bg-lowerfooter">
    <div class="lower-footer">
      <div class="container">
        <div class="col-sm-3" style="padding: 0px">
        <p class="copy-right">Copyright &copy; . All Rights Reserved.</p>
        </div>
        
      <!--  <div style="margin-left:17%; float:left;"><img src="http://smallseotools.com/visitor-counter/counter.php?code=4bcf5a0ccb067d58ba35e9946e024965&style=0004&pad=5&type=ip&initCount=502"title="Visitor Counter" Alt="Visitor Counter" border="0"></div> -->
        <div class="col-sm-6" style="padding: 0px; text-align:center;">
<!-- hitwebcounter Code START -->
        
        <!-- hitwebcounter Code END -->
      <%--   <div class="social-media social-media1">
              <ul>
                <li><a href="#"><i class="fa fa-facebook" style="color:#5c72a4"></i></a></li>
                <li><a href="#"><i class="fa fa-twitter" style="color:#0eb1f2"></i></a></li>
                <li><a href="#"><i class="fa fa-google-plus" style="color:#c74d38"></i></a></li>
                <li><a href="#"><i class="fa fa-pinterest" style="color:#b8252b"></i></a></li>
                <li><a href="#"><i class="fa fa-linkedin" style="color:#1e83d5"></i></a></li>
              </ul>
            </div> --%>
        </div>
        <div class="col-sm-3" style="padding: 0px">
        <div  style=" float:right;">Designed and developed by <a href="http://trac.telangana.gov.in/" target="_blank">TRAC</a></div>
        </div>
      </div>
    </div>
  </div>

</footer>
<script type="text/javascript" src="https://www.apiic.in/wp-content/themes/apindus/js/jquery.js"></script>
<script type="text/javascript" src="https://www.apiic.in/wp-content/themes/apindus/js/bootstrap.js"></script>
<script type="text/javascript" src="https://www.apiic.in/wp-content/themes/apindus/js/owl.carousel.min.js"></script>
<script type="text/javascript" src="https://www.apiic.in/wp-content/themes/apindus/js/script.js"></script>
<script type="text/javascript" src="https://www.apiic.in/wp-content/themes/apindus/js/modernizr.custom.79639.js"></script>
<script type='text/javascript' src='https://www.apiic.in/wp-content/plugins/contact-form-7/includes/js/jquery.form.min.js?ver=3.15'></script>
<script type='text/javascript'>
/* <![CDATA[ */
var _wpcf7 = {"loaderUrl":"https:\/\/www.apiic.in\/wp-content\/plugins\/contact-form-7\/images\/ajax-loader.gif","sending":"Sending ..."};
/* ]]> */
</script>
<script type='text/javascript' src='https://www.apiic.in/wp-content/plugins/contact-form-7/includes/js/scripts.js?ver=3.3'></script>
<script type='text/javascript' src='https://www.apiic.in/wp-includes/js/imagesloaded.min.js?ver=3.2.0'></script>
<script type='text/javascript' src='https://www.apiic.in/wp-includes/js/masonry.min.js?ver=3.3.2'></script>
<script type='text/javascript' src='https://www.apiic.in/wp-includes/js/jquery/jquery.masonry.min.js?ver=3.1.2b'></script>
<script type='text/javascript' src='https://www.apiic.in/wp-content/themes/apindus/js/functions.js?ver=20150330'></script>
<script type='text/javascript' src='https://www.apiic.in/wp-includes/js/wp-embed.min.js?ver=4.9.15'></script>


<script type="text/javascript">
    // Build the chart
    window.onload = getchart();
    function getchart() {
       // alert(document.getElementById('Label4').innerHTML + "," + parseInt(document.getElementById('Label6').innerHTM) + "," + parseInt(document.getElementById('Label8').innerHTML));
        Highcharts.chart('container', {
            chart: {
                plotBackgroundColor: null,
                plotBorderWidth: null,
                plotShadow: false,
                type: 'pie'
            },
            title: {
                text: 'INDUSTRIAL PARKS STATUS'
            },
            tooltip: {

                formatter: function () {

                    return '<b>' + this.point.name + '</b>: ' + Highcharts.numberFormat(this.percentage, 0) + ' %';

                }

            },
            accessibility: {
                point: {
                    valueSuffix: '%'
                }
            },
            plotOptions: {
                pie: {
                    allowPointSelect: true,
                    cursor: 'pointer',
                    dataLabels: {
                        enabled: false
                    },
                    showInLegend: true
                }
            },
            series: [{
                name: 'Brands',
                colorByPoint: true,
                data: [ {
                    name: 'Alloted',
                    y: parseInt(document.getElementById('Label4').innerHTML)
                }, {
                    name: 'Vacant',
                    y: parseInt(document.getElementById('Label6').innerHTML)
                }, {
                    name: 'Vacant but Unallottable',
                    y: parseInt(document.getElementById('Label8').innerHTML)
                }]
            }]
        });
    }


</script>
</body></html>
