USE [uManage]
GO

/****** Object:  Table [dbo].[EmailTemplates]    Script Date: 04/28/2011 22:57:49 ******/

INSERT [dbo].[EmailTemplates] ([TemplateId], [Title], [Body], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsEnabled]) 
VALUES (N'17c8e18b-4943-41b2-8680-439f37fe08e4', N'Password Expiration Reminder'
		 , N'<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
			<html>
				<head>
					<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
					<!-- Facebook sharing information tags -->
					<meta content="*|MC:SUBJECT|*" property="og:title" />
					<title>*|MC:SUBJECT|*</title>
					<style type="text/css">
						/* Client-specific Styles */#outlook a
						{
							padding: 0;
						}
						/* Force Outlook to provide a "view in browser" button. */body
						{
							width: 100% !important;
						}
						/* Force Hotmail to display emails at full width */body
						{
							-webkit-text-size-adjust: none;
						}
						/* Prevent Webkit platforms from changing default text sizes. *//* Reset Styles */body
						{
							margin: 0;
							padding: 0;
						}
						img
						{
							border: none;
							font-size: 14px;
							font-weight: bold;
							height: auto;
							line-height: 100%;
							outline: none;
							text-decoration: none;
							text-transform: capitalize;
						}
						#backgroundTable
						{
							height: 100% !important;
							margin: 0;
							padding: 0;
							width: 100% !important;
						}
						/* Template Styles *//* /\/\/\/\/\/\/\/\/\/\ STANDARD STYLING: COMMON PAGE ELEMENTS /\/\/\/\/\/\/\/\/\/\ *//** * @tab Page * @section background color * @tip Set the background color for your email. You may want to choose one that matches your company''s branding. * @theme page */body, #backgroundTable
						{
							/*@editable*/
							background-color: #FAFAFA;
						}
						/** * @tab Page * @section email border * @tip Set the border for your email. */#templateContainer
						{
							/*@editable*/
							border: 1px solid #DDDDDD;
						}
						/** * @tab Page * @section heading 1 * @tip Set the styling for all first-level headings in your emails. These should be the largest of your headings. * @style heading 1 */h1, .h1
						{
							/*@editable*/
							color: #202020;
							display: block; /*@editable*/
							font-family: Arial; /*@editable*/
							font-size: 34px; /*@editable*/
							font-weight: bold; /*@editable*/
							line-height: 100%;
							margin-top: 0;
							margin-right: 0;
							margin-bottom: 10px;
							margin-left: 0; /*@editable*/
							text-align: left;
						}
						/** * @tab Page * @section heading 2 * @tip Set the styling for all second-level headings in your emails. * @style heading 2 */h2, .h2
						{
							/*@editable*/
							color: #202020;
							display: block; /*@editable*/
							font-family: Arial; /*@editable*/
							font-size: 30px; /*@editable*/
							font-weight: bold; /*@editable*/
							line-height: 100%;
							margin-top: 0;
							margin-right: 0;
							margin-bottom: 10px;
							margin-left: 0; /*@editable*/
							text-align: left;
						}
						/** * @tab Page * @section heading 3 * @tip Set the styling for all third-level headings in your emails. * @style heading 3 */h3, .h3
						{
							/*@editable*/
							color: #202020;
							display: block; /*@editable*/
							font-family: Arial; /*@editable*/
							font-size: 26px; /*@editable*/
							font-weight: bold; /*@editable*/
							line-height: 100%;
							margin-top: 0;
							margin-right: 0;
							margin-bottom: 10px;
							margin-left: 0; /*@editable*/
							text-align: left;
						}
						/** * @tab Page * @section heading 4 * @tip Set the styling for all fourth-level headings in your emails. These should be the smallest of your headings. * @style heading 4 */h4, .h4
						{
							/*@editable*/
							color: #202020;
							display: block; /*@editable*/
							font-family: Arial; /*@editable*/
							font-size: 22px; /*@editable*/
							font-weight: bold; /*@editable*/
							line-height: 100%;
							margin-top: 0;
							margin-right: 0;
							margin-bottom: 10px;
							margin-left: 0; /*@editable*/
							text-align: left;
						}
						/* /\/\/\/\/\/\/\/\/\/\ STANDARD STYLING: PREHEADER /\/\/\/\/\/\/\/\/\/\ *//** * @tab Header * @section preheader style * @tip Set the background color for your email''s preheader area. * @theme page */#templatePreheader
						{
							/*@editable*/
							background-color: #FAFAFA;
						}
						/** * @tab Header * @section preheader text * @tip Set the styling for your email''s preheader text. Choose a size and color that is easy to read. */.preheaderContent div
						{
							/*@editable*/
							color: #505050; /*@editable*/
							font-family: Arial; /*@editable*/
							font-size: 10px; /*@editable*/
							line-height: 100%; /*@editable*/
							text-align: left;
						}
						/** * @tab Header * @section preheader link * @tip Set the styling for your email''s preheader links. Choose a color that helps them stand out from your text. */.preheaderContent div a:link, .preheaderContent div a:visited
						{
							/*@editable*/
							color: #336699; /*@editable*/
							font-weight: normal; /*@editable*/
							text-decoration: underline;
						}
						/* /\/\/\/\/\/\/\/\/\/\ STANDARD STYLING: HEADER /\/\/\/\/\/\/\/\/\/\ *//** * @tab Header * @section header style * @tip Set the background color and border for your email''s header area. * @theme header */#templateHeader
						{
							/*@editable*/
							background-color: #D8E2EA; /*@editable*/
							border-bottom: 0;
						}
						/** * @tab Header * @section header text * @tip Set the styling for your email''s header text. Choose a size and color that is easy to read. */.headerContent
						{
							/*@editable*/
							color: #202020; /*@editable*/
							font-family: Arial; /*@editable*/
							font-size: 34px; /*@editable*/
							font-weight: bold; /*@editable*/
							line-height: 100%; /*@editable*/
							padding: 0; /*@editable*/
							text-align: center; /*@editable*/
							vertical-align: middle;
						}
						/** * @tab Header * @section header link * @tip Set the styling for your email''s header links. Choose a color that helps them stand out from your text. */.headerContent a:link, .headerContent a:visited
						{
							/*@editable*/
							color: #336699; /*@editable*/
							font-weight: normal; /*@editable*/
							text-decoration: underline;
						}
						#headerImage
						{
							height: auto;
							max-width: 600px !important;
						}
						/* /\/\/\/\/\/\/\/\/\/\ STANDARD STYLING: MAIN BODY /\/\/\/\/\/\/\/\/\/\ *//** * @tab Body * @section body style * @tip Set the background color for your email''s body area. */#templateContainer, .bodyContent
						{
							/*@editable*/
							background-color: #FDFDFD;
						}
						/** * @tab Body * @section body text * @tip Set the styling for your email''s main content text. Choose a size and color that is easy to read. * @theme main */.bodyContent div
						{
							/*@editable*/
							color: #505050; /*@editable*/
							font-family: Arial; /*@editable*/
							font-size: 14px; /*@editable*/
							line-height: 150%; /*@editable*/
							text-align: left;
						}
						/** * @tab Body * @section body link * @tip Set the styling for your email''s main content links. Choose a color that helps them stand out from your text. */.bodyContent div a:link, .bodyContent div a:visited
						{
							/*@editable*/
							color: #336699; /*@editable*/
							font-weight: normal; /*@editable*/
							text-decoration: underline;
						}
						.bodyContent img
						{
							display: inline;
							height: auto;
						}
						/* /\/\/\/\/\/\/\/\/\/\ STANDARD STYLING: FOOTER /\/\/\/\/\/\/\/\/\/\ *//** * @tab Footer * @section footer style * @tip Set the background color and top border for your email''s footer area. * @theme footer */#templateFooter
						{
							/*@editable*/
							background-color: #FDFDFD; /*@editable*/
							border-top: 0;
						}
						/** * @tab Footer * @section footer text * @tip Set the styling for your email''s footer text. Choose a size and color that is easy to read. * @theme footer */.footerContent div
						{
							/*@editable*/
							color: #707070; /*@editable*/
							font-family: Arial; /*@editable*/
							font-size: 12px; /*@editable*/
							line-height: 125%; /*@editable*/
							text-align: left;
						}
						/** * @tab Footer * @section footer link * @tip Set the styling for your email''s footer links. Choose a color that helps them stand out from your text. */.footerContent div a:link, .footerContent div a:visited
						{
							/*@editable*/
							color: #336699; /*@editable*/
							font-weight: normal; /*@editable*/
							text-decoration: underline;
						}
						.footerContent img
						{
							display: inline;
						}
						/** * @tab Footer * @section social bar style * @tip Set the background color and border for your email''s footer social bar. * @theme footer */#social
						{
							/*@editable*/
							background-color: #FAFAFA; /*@editable*/
							border: 0;
						}
						/** * @tab Footer * @section social bar style * @tip Set the background color and border for your email''s footer social bar. */#social div
						{
							/*@editable*/
							text-align: center;
						}
						/** * @tab Footer * @section utility bar style * @tip Set the background color and border for your email''s footer utility bar. * @theme footer */#utility
						{
							/*@editable*/
							background-color: #FDFDFD; /*@editable*/
							border: 0;
						}
						/** * @tab Footer * @section utility bar style * @tip Set the background color and border for your email''s footer utility bar. */#utility div
						{
							/*@editable*/
							text-align: center;
						}
						#monkeyRewards img
						{
							max-width: 190px;
						}
					</style>
				</head>
				<body leftmargin="0" marginwidth="0" topmargin="0" marginheight="0" offset="0">
					<br />
					<center>
						<table width="100%" height="100%" id="backgroundTable" border="0" cellspacing="0"
							cellpadding="0">
							<tbody>
								<tr>
									<td align="center" valign="top">
										<table width="600" id="templateContainer" border="0" cellspacing="0" cellpadding="0">
											<tbody>
												<tr>
													<td align="center" valign="top">
														<!-- // Begin Template Header \\ -->
														<table width="600" id="templateHeader" border="0" cellspacing="0" cellpadding="0">
															<tbody>
																<tr>
																	<td class="headerContent">
																		<!-- // Begin Module: Standard Header Image \\ -->
																		$title$<!-- // End Module: Standard Header Image \\ -->
																	</td>
																</tr>
															</tbody>
														</table>
														<!-- // End Template Header \\ -->
													</td>
												</tr>
												<tr>
													<td align="center" valign="top">
														<!-- // Begin Template Body \\ -->
														<table width="600" id="templateBody" border="0" cellspacing="0" cellpadding="0">
															<tbody>
																<tr>
																	<td class="bodyContent" valign="top">
																		<!-- // Begin Module: Standard Content \\ -->
																		<table width="100%" border="0" cellspacing="0" cellpadding="20">
																			<tbody>
																				<tr>
																					<td valign="top">
																						<div mc:edit="std_content00">
																							<h4 class="h4">
																								Password Expiration Reminder</h4>
																							$EmployeeDTO.FirstName$, this is a reminder that your password will expire on <b>$EmployeeDTO.PasswordExpDate$</b>.
																							In order to avoid problems and downtime you can update your personal information
																							online.<br />
																							<br />
																							To update your information <a shape="rect" href="$link$" target="_blank">click here</a>.<br />
																							<br />
																							$EmployeeDTO.UpnUsername$</div>
																					</td>
																				</tr>
																			</tbody>
																		</table>
																		<!-- // End Module: Standard Content \\ -->
																	</td>
																</tr>
															</tbody>
														</table>
														<!-- // End Template Body \\ -->
														<td>
												</tr>
											</tbody>
										</table>
									</td>
								</tr>
							</tbody>
						</table>
					</center>
				</body>
				</html>'
		 , CAST(0x00009ED3000B0CC8 AS DateTime), NULL, N'uManage', NULL, 1)

INSERT [dbo].[EmailTemplates] ([TemplateId], [Title], [Body], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsEnabled]) 
VALUES (N'368b9904-16d7-4c8e-81c1-5eb51937d50f', N'User Account Expiration Reminder'
		, N'<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
			<html>
				<head>
					<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
        
					<!-- Facebook sharing information tags -->
					<meta property="og:title" content="*|MC:SUBJECT|*" />
        
					<title>*|MC:SUBJECT|*</title>
					<style type="text/css">
						/* Client-specific Styles */
						#outlook a{padding:0;} /* Force Outlook to provide a "view in browser" button. */
						body{width:100% !important;} /* Force Hotmail to display emails at full width */
						body{-webkit-text-size-adjust:none;} /* Prevent Webkit platforms from changing default text sizes. */

						/* Reset Styles */
						body{margin:0; padding:0;}
						img{border:none; font-size:14px; font-weight:bold; height:auto; line-height:100%; outline:none; text-decoration:none; text-transform:capitalize;}
						#backgroundTable{height:100% !important; margin:0; padding:0; width:100% !important;}

						/* Template Styles */

						/* /\/\/\/\/\/\/\/\/\/\ STANDARD STYLING: COMMON PAGE ELEMENTS /\/\/\/\/\/\/\/\/\/\ */

						/**
						* @tab Page
						* @section background color
						* @tip Set the background color for your email. You may want to choose one that matches your company''s branding.
						* @theme page
						*/
						body, #backgroundTable{
							/*@editable*/ background-color:#FAFAFA;
						}

						/**
						* @tab Page
						* @section email border
						* @tip Set the border for your email.
						*/
						#templateContainer{
							/*@editable*/ border: 1px solid #DDDDDD;
						}

						/**
						* @tab Page
						* @section heading 1
						* @tip Set the styling for all first-level headings in your emails. These should be the largest of your headings.
						* @style heading 1
						*/
						h1, .h1{
							/*@editable*/ color:#202020;
							display:block;
							/*@editable*/ font-family:Arial;
							/*@editable*/ font-size:34px;
							/*@editable*/ font-weight:bold;
							/*@editable*/ line-height:100%;
							margin-top:0;
							margin-right:0;
							margin-bottom:10px;
							margin-left:0;
							/*@editable*/ text-align:left;
						}

						/**
						* @tab Page
						* @section heading 2
						* @tip Set the styling for all second-level headings in your emails.
						* @style heading 2
						*/
						h2, .h2{
							/*@editable*/ color:#202020;
							display:block;
							/*@editable*/ font-family:Arial;
							/*@editable*/ font-size:30px;
							/*@editable*/ font-weight:bold;
							/*@editable*/ line-height:100%;
							margin-top:0;
							margin-right:0;
							margin-bottom:10px;
							margin-left:0;
							/*@editable*/ text-align:left;
						}

						/**
						* @tab Page
						* @section heading 3
						* @tip Set the styling for all third-level headings in your emails.
						* @style heading 3
						*/
						h3, .h3{
							/*@editable*/ color:#202020;
							display:block;
							/*@editable*/ font-family:Arial;
							/*@editable*/ font-size:26px;
							/*@editable*/ font-weight:bold;
							/*@editable*/ line-height:100%;
							margin-top:0;
							margin-right:0;
							margin-bottom:10px;
							margin-left:0;
							/*@editable*/ text-align:left;
						}

						/**
						* @tab Page
						* @section heading 4
						* @tip Set the styling for all fourth-level headings in your emails. These should be the smallest of your headings.
						* @style heading 4
						*/
						h4, .h4{
							/*@editable*/ color:#202020;
							display:block;
							/*@editable*/ font-family:Arial;
							/*@editable*/ font-size:22px;
							/*@editable*/ font-weight:bold;
							/*@editable*/ line-height:100%;
							margin-top:0;
							margin-right:0;
							margin-bottom:10px;
							margin-left:0;
							/*@editable*/ text-align:left;
						}

						/* /\/\/\/\/\/\/\/\/\/\ STANDARD STYLING: PREHEADER /\/\/\/\/\/\/\/\/\/\ */

						/**
						* @tab Header
						* @section preheader style
						* @tip Set the background color for your email''s preheader area.
						* @theme page
						*/
						#templatePreheader{
							/*@editable*/ background-color:#FAFAFA;
						}

						/**
						* @tab Header
						* @section preheader text
						* @tip Set the styling for your email''s preheader text. Choose a size and color that is easy to read.
						*/
						.preheaderContent div{
							/*@editable*/ color:#505050;
							/*@editable*/ font-family:Arial;
							/*@editable*/ font-size:10px;
							/*@editable*/ line-height:100%;
							/*@editable*/ text-align:left;
						}

						/**
						* @tab Header
						* @section preheader link
						* @tip Set the styling for your email''s preheader links. Choose a color that helps them stand out from your text.
						*/
						.preheaderContent div a:link, .preheaderContent div a:visited{
							/*@editable*/ color:#336699;
							/*@editable*/ font-weight:normal;
							/*@editable*/ text-decoration:underline;
						}

						/* /\/\/\/\/\/\/\/\/\/\ STANDARD STYLING: HEADER /\/\/\/\/\/\/\/\/\/\ */

						/**
						* @tab Header
						* @section header style
						* @tip Set the background color and border for your email''s header area.
						* @theme header
						*/
						#templateHeader{
							/*@editable*/ background-color:#D8E2EA;
							/*@editable*/ border-bottom:0;
						}

						/**
						* @tab Header
						* @section header text
						* @tip Set the styling for your email''s header text. Choose a size and color that is easy to read.
						*/
						.headerContent{
							/*@editable*/ color:#202020;
							/*@editable*/ font-family:Arial;
							/*@editable*/ font-size:34px;
							/*@editable*/ font-weight:bold;
							/*@editable*/ line-height:100%;
							/*@editable*/ padding:0;
							/*@editable*/ text-align:center;
							/*@editable*/ vertical-align:middle;
						}

						/**
						* @tab Header
						* @section header link
						* @tip Set the styling for your email''s header links. Choose a color that helps them stand out from your text.
						*/
						.headerContent a:link, .headerContent a:visited{
							/*@editable*/ color:#336699;
							/*@editable*/ font-weight:normal;
							/*@editable*/ text-decoration:underline;
						}

						#headerImage{
							height:auto;
							max-width:600px !important;
						}

						/* /\/\/\/\/\/\/\/\/\/\ STANDARD STYLING: MAIN BODY /\/\/\/\/\/\/\/\/\/\ */

						/**
						* @tab Body
						* @section body style
						* @tip Set the background color for your email''s body area.
						*/
						#templateContainer, .bodyContent{
							/*@editable*/ background-color:#FDFDFD;
						}

						/**
						* @tab Body
						* @section body text
						* @tip Set the styling for your email''s main content text. Choose a size and color that is easy to read.
						* @theme main
						*/
						.bodyContent div{
							/*@editable*/ color:#505050;
							/*@editable*/ font-family:Arial;
							/*@editable*/ font-size:14px;
							/*@editable*/ line-height:150%;
							/*@editable*/ text-align:left;
						}

						/**
						* @tab Body
						* @section body link
						* @tip Set the styling for your email''s main content links. Choose a color that helps them stand out from your text.
						*/
						.bodyContent div a:link, .bodyContent div a:visited{
							/*@editable*/ color:#336699;
							/*@editable*/ font-weight:normal;
							/*@editable*/ text-decoration:underline;
						}

						.bodyContent img{
							display:inline;
							height:auto;
						}

						/* /\/\/\/\/\/\/\/\/\/\ STANDARD STYLING: FOOTER /\/\/\/\/\/\/\/\/\/\ */

						/**
						* @tab Footer
						* @section footer style
						* @tip Set the background color and top border for your email''s footer area.
						* @theme footer
						*/
						#templateFooter{
							/*@editable*/ background-color:#FDFDFD;
							/*@editable*/ border-top:0;
						}

						/**
						* @tab Footer
						* @section footer text
						* @tip Set the styling for your email''s footer text. Choose a size and color that is easy to read.
						* @theme footer
						*/
						.footerContent div{
							/*@editable*/ color:#707070;
							/*@editable*/ font-family:Arial;
							/*@editable*/ font-size:12px;
							/*@editable*/ line-height:125%;
							/*@editable*/ text-align:left;
						}

						/**
						* @tab Footer
						* @section footer link
						* @tip Set the styling for your email''s footer links. Choose a color that helps them stand out from your text.
						*/
						.footerContent div a:link, .footerContent div a:visited{
							/*@editable*/ color:#336699;
							/*@editable*/ font-weight:normal;
							/*@editable*/ text-decoration:underline;
						}

						.footerContent img{
							display:inline;
						}

						/**
						* @tab Footer
						* @section social bar style
						* @tip Set the background color and border for your email''s footer social bar.
						* @theme footer
						*/
						#social{
							/*@editable*/ background-color:#FAFAFA;
							/*@editable*/ border:0;
						}

						/**
						* @tab Footer
						* @section social bar style
						* @tip Set the background color and border for your email''s footer social bar.
						*/
						#social div{
							/*@editable*/ text-align:center;
						}

						/**
						* @tab Footer
						* @section utility bar style
						* @tip Set the background color and border for your email''s footer utility bar.
						* @theme footer
						*/
						#utility{
							/*@editable*/ background-color:#FDFDFD;
							/*@editable*/ border:0;
						}

						/**
						* @tab Footer
						* @section utility bar style
						* @tip Set the background color and border for your email''s footer utility bar.
						*/
						#utility div{
							/*@editable*/ text-align:center;
						}

						#monkeyRewards img{
							max-width:190px;
						}
					</style>
				</head>
				<body leftmargin="0" marginwidth="0" topmargin="0" marginheight="0" offset="0">
				<br />
    				<center>
        				<table border="0" cellpadding="0" cellspacing="0" height="100%" width="100%" id="backgroundTable">
            				<tr>
                				<td align="center" valign="top">
                    				<table border="0" cellpadding="0" cellspacing="0" width="600" id="templateContainer">
                        				<tr>
                            				<td align="center" valign="top">
												<!-- // Begin Template Header \\ -->
                                				<table border="0" cellpadding="0" cellspacing="0" width="600" id="templateHeader">
													<tr>
														<td class="headerContent">
                                            
                                            				<!-- // Begin Module: Standard Header Image \\ -->
                                            				$title$
                                            				<!-- // End Module: Standard Header Image \\ -->
                                            
														</td>
													</tr>
												</table>
												<!-- // End Template Header \\ -->
											</td>
										</tr>
                        				<tr>
                            				<td align="center" valign="top">
												<!-- // Begin Template Body \\ -->
                                				<table border="0" cellpadding="0" cellspacing="0" width="600" id="templateBody">
                                    				<tr>
														<td valign="top" class="bodyContent">
                                
															<!-- // Begin Module: Standard Content \\ -->
															<table border="0" cellpadding="20" cellspacing="0" width="100%">
																<tr>
																	<td valign="top">
																		<div mc:edit="std_content00">
																		<h4 class="h4">User Account Expiration Reminder</h4>
																		$EmployeeDTO.FirstName$, this is a reminder that your account will expire on <b>$EmployeeDTO.AccountExpDate$</b>.  In order to avoid problems and downtime you can update your personal information online.
																		<br />
																		<br />
																		To update your information <a href="$link$" target="_blank">click here</a>.
																		<br />
																		<br />
																		$EmployeeDTO.UpnUsername$
																		</div>
																	</td>
																</tr>
															</table>
															<!-- // End Module: Standard Content \\ -->
                                                                                                
														</td>
													</tr>
												</table>
												<!-- // End Template Body \\ -->
											</td>
										</tr>                        	
									</table>                        
									<br />
								</td>
							</tr>
						</table>
					</center>
				</body>
			</html>'
		, CAST(0x00009ED3000B3EA2 AS DateTime), NULL, N'uManage', NULL, 1)

INSERT [dbo].[EmailTemplates] ([TemplateId], [Title], [Body], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsEnabled]) 
VALUES (N'eb1cb687-6af9-4883-9d5c-c91944507f8a', N'New Account Created'
		, N'<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
			<html>
			<head>
				<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
				<!-- Facebook sharing information tags -->
				<meta property="og:title" content="*|MC:SUBJECT|*" />
				<title>*|MC:SUBJECT|*</title>
				<style type="text/css">
					/* Client-specific Styles */#outlook a
					{
						padding: 0;
					}
					/* Force Outlook to provide a "view in browser" button. */body
					{
						width: 100% !important;
					}
					/* Force Hotmail to display emails at full width */body
					{
						-webkit-text-size-adjust: none;
					}
					/* Prevent Webkit platforms from changing default text sizes. *//* Reset Styles */body
					{
						margin: 0;
						padding: 0;
					}
					img
					{
						border: none;
						font-size: 14px;
						font-weight: bold;
						height: auto;
						line-height: 100%;
						outline: none;
						text-decoration: none;
						text-transform: capitalize;
					}
					#backgroundTable
					{
						height: 100% !important;
						margin: 0;
						padding: 0;
						width: 100% !important;
					}
					/* Template Styles *//* /\/\/\/\/\/\/\/\/\/\ STANDARD STYLING: COMMON PAGE ELEMENTS /\/\/\/\/\/\/\/\/\/\ *//**    * @tab Page    * @section background color    * @tip Set the background color for your email. You may want to choose one that matches your company''s branding.    * @theme page    */body, #backgroundTable
					{
						/*@editable*/
						background-color: #FAFAFA;
					}
					/**    * @tab Page    * @section email border    * @tip Set the border for your email.    */#templateContainer
					{
						/*@editable*/
						border: 1px solid #DDDDDD;
					}
					/**    * @tab Page    * @section heading 1    * @tip Set the styling for all first-level headings in your emails. These should be the largest of your headings.    * @style heading 1    */h1, .h1
					{
						/*@editable*/
						color: #202020;
						display: block; /*@editable*/
						font-family: Arial; /*@editable*/
						font-size: 34px; /*@editable*/
						font-weight: bold; /*@editable*/
						line-height: 100%;
						margin-top: 0;
						margin-right: 0;
						margin-bottom: 10px;
						margin-left: 0; /*@editable*/
						text-align: left;
					}
					/**    * @tab Page    * @section heading 2    * @tip Set the styling for all second-level headings in your emails.    * @style heading 2    */h2, .h2
					{
						/*@editable*/
						color: #202020;
						display: block; /*@editable*/
						font-family: Arial; /*@editable*/
						font-size: 30px; /*@editable*/
						font-weight: bold; /*@editable*/
						line-height: 100%;
						margin-top: 0;
						margin-right: 0;
						margin-bottom: 10px;
						margin-left: 0; /*@editable*/
						text-align: left;
					}
					/**    * @tab Page    * @section heading 3    * @tip Set the styling for all third-level headings in your emails.    * @style heading 3    */h3, .h3
					{
						/*@editable*/
						color: #202020;
						display: block; /*@editable*/
						font-family: Arial; /*@editable*/
						font-size: 26px; /*@editable*/
						font-weight: bold; /*@editable*/
						line-height: 100%;
						margin-top: 0;
						margin-right: 0;
						margin-bottom: 10px;
						margin-left: 0; /*@editable*/
						text-align: left;
					}
					/**    * @tab Page    * @section heading 4    * @tip Set the styling for all fourth-level headings in your emails. These should be the smallest of your headings.    * @style heading 4    */h4, .h4
					{
						/*@editable*/
						color: #202020;
						display: block; /*@editable*/
						font-family: Arial; /*@editable*/
						font-size: 22px; /*@editable*/
						font-weight: bold; /*@editable*/
						line-height: 100%;
						margin-top: 0;
						margin-right: 0;
						margin-bottom: 10px;
						margin-left: 0; /*@editable*/
						text-align: left;
					}
					/* /\/\/\/\/\/\/\/\/\/\ STANDARD STYLING: PREHEADER /\/\/\/\/\/\/\/\/\/\ *//**    * @tab Header    * @section preheader style    * @tip Set the background color for your email''s preheader area.    * @theme page    */#templatePreheader
					{
						/*@editable*/
						background-color: #FAFAFA;
					}
					/**    * @tab Header    * @section preheader text    * @tip Set the styling for your email''s preheader text. Choose a size and color that is easy to read.    */.preheaderContent div
					{
						/*@editable*/
						color: #505050; /*@editable*/
						font-family: Arial; /*@editable*/
						font-size: 10px; /*@editable*/
						line-height: 100%; /*@editable*/
						text-align: left;
					}
					/**    * @tab Header    * @section preheader link    * @tip Set the styling for your email''s preheader links. Choose a color that helps them stand out from your text.    */.preheaderContent div a:link, .preheaderContent div a:visited
					{
						/*@editable*/
						color: #336699; /*@editable*/
						font-weight: normal; /*@editable*/
						text-decoration: underline;
					}
					/* /\/\/\/\/\/\/\/\/\/\ STANDARD STYLING: HEADER /\/\/\/\/\/\/\/\/\/\ *//**    * @tab Header    * @section header style    * @tip Set the background color and border for your email''s header area.    * @theme header    */#templateHeader
					{
						/*@editable*/
						background-color: #D8E2EA; /*@editable*/
						border-bottom: 0;
					}
					/**    * @tab Header    * @section header text    * @tip Set the styling for your email''s header text. Choose a size and color that is easy to read.    */.headerContent
					{
						/*@editable*/
						color: #202020; /*@editable*/
						font-family: Arial; /*@editable*/
						font-size: 34px; /*@editable*/
						font-weight: bold; /*@editable*/
						line-height: 100%; /*@editable*/
						padding: 0; /*@editable*/
						text-align: center; /*@editable*/
						vertical-align: middle;
					}
					/**    * @tab Header    * @section header link    * @tip Set the styling for your email''s header links. Choose a color that helps them stand out from your text.    */.headerContent a:link, .headerContent a:visited
					{
						/*@editable*/
						color: #336699; /*@editable*/
						font-weight: normal; /*@editable*/
						text-decoration: underline;
					}
					#headerImage
					{
						height: auto;
						max-width: 600px !important;
					}
					/* /\/\/\/\/\/\/\/\/\/\ STANDARD STYLING: MAIN BODY /\/\/\/\/\/\/\/\/\/\ *//**    * @tab Body    * @section body style    * @tip Set the background color for your email''s body area.    */#templateContainer, .bodyContent
					{
						/*@editable*/
						background-color: #FDFDFD;
					}
					/**    * @tab Body    * @section body text    * @tip Set the styling for your email''s main content text. Choose a size and color that is easy to read.    * @theme main    */.bodyContent div
					{
						/*@editable*/
						color: #505050; /*@editable*/
						font-family: Arial; /*@editable*/
						font-size: 14px; /*@editable*/
						line-height: 150%; /*@editable*/
						text-align: left;
					}
					/**    * @tab Body    * @section body link    * @tip Set the styling for your email''s main content links. Choose a color that helps them stand out from your text.    */.bodyContent div a:link, .bodyContent div a:visited
					{
						/*@editable*/
						color: #336699; /*@editable*/
						font-weight: normal; /*@editable*/
						text-decoration: underline;
					}
					.bodyContent img
					{
						display: inline;
						height: auto;
					}
					/* /\/\/\/\/\/\/\/\/\/\ STANDARD STYLING: FOOTER /\/\/\/\/\/\/\/\/\/\ *//**    * @tab Footer    * @section footer style    * @tip Set the background color and top border for your email''s footer area.    * @theme footer    */#templateFooter
					{
						/*@editable*/
						background-color: #FDFDFD; /*@editable*/
						border-top: 0;
					}
					/**    * @tab Footer    * @section footer text    * @tip Set the styling for your email''s footer text. Choose a size and color that is easy to read.    * @theme footer    */.footerContent div
					{
						/*@editable*/
						color: #707070; /*@editable*/
						font-family: Arial; /*@editable*/
						font-size: 12px; /*@editable*/
						line-height: 125%; /*@editable*/
						text-align: left;
					}
					/**    * @tab Footer    * @section footer link    * @tip Set the styling for your email''s footer links. Choose a color that helps them stand out from your text.    */.footerContent div a:link, .footerContent div a:visited
					{
						/*@editable*/
						color: #336699; /*@editable*/
						font-weight: normal; /*@editable*/
						text-decoration: underline;
					}
					.footerContent img
					{
						display: inline;
					}
					/**    * @tab Footer    * @section social bar style    * @tip Set the background color and border for your email''s footer social bar.    * @theme footer    */#social
					{
						/*@editable*/
						background-color: #FAFAFA; /*@editable*/
						border: 0;
					}
					/**    * @tab Footer    * @section social bar style    * @tip Set the background color and border for your email''s footer social bar.    */#social div
					{
						/*@editable*/
						text-align: center;
					}
					/**    * @tab Footer    * @section utility bar style    * @tip Set the background color and border for your email''s footer utility bar.    * @theme footer    */#utility
					{
						/*@editable*/
						background-color: #FDFDFD; /*@editable*/
						border: 0;
					}
					/**    * @tab Footer    * @section utility bar style    * @tip Set the background color and border for your email''s footer utility bar.    */#utility div
					{
						/*@editable*/
						text-align: center;
					}
					#monkeyRewards img
					{
						max-width: 190px;
					}
				</style>
			</head>
			<body leftmargin="0" marginwidth="0" topmargin="0" marginheight="0" offset="0">
				<br />
				<center>
					<table border="0" cellpadding="0" cellspacing="0" height="100%" width="100%" id="backgroundTable">
						<tr>
							<td align="center" valign="top">
								<table border="0" cellpadding="0" cellspacing="0" width="600" id="templateContainer">
									<tr>
										<td align="center" valign="top">
											<!-- // Begin Template Header \\ -->
											<table border="0" cellpadding="0" cellspacing="0" width="600" id="templateHeader">
												<tr>
													<td class="headerContent">
														<!-- // Begin Module: Standard Header Image \\ -->
														$title$
														<!-- // End Module: Standard Header Image \\ -->
													</td>
												</tr>
											</table>
											<!-- // End Template Header \\ -->
										</td>
									</tr>
									<tr>
										<td align="center" valign="top">
											<!-- // Begin Template Body \\ -->
											<table border="0" cellpadding="0" cellspacing="0" width="600" id="templateBody">
												<tr>
													<td valign="top" class="bodyContent">
														<!-- // Begin Module: Standard Content \\ -->
														<table border="0" cellpadding="20" cellspacing="0" width="100%">
															<tr>
																<td valign="top">
																	<div mc:edit="std_content00">
																		<h4 class="h4">
																			New Account Created</h4>
																		$EmployeeDTO.FirstName$, a new user account has been created for you.&nbsp; The
																		information below will assist you with logging in to the computer systems.&nbsp;
																		You can update your information at any time by using the link below.
																		<br />
																		<br />
																		<strong>Username:</strong>&nbsp;$EmployeeDTO.UpnUsername$
																		<br />
																		<strong>Password:</strong>&nbsp;$password$
																		<br />
																		<br />
																		To update your information <a href="$link$" target="_blank">click here</a>.
																	</div>
																</td>
															</tr>
															<tr>
																<td valign="top">
																	<div mc:edit="std_content00">
																		<h4 class="h4">
																			How To Login</h4>
																		<strong>Windows 7 and Vista</strong>
																		<br />
																		<ol>
																			<li>Press Control + Alt + Delete when prompted.</li>
																			<li>Enter your username (<strong>$EmployeeDTO.UpnUsername$</strong>).</li>
																			<li>Enter your password (<strong>$password$</strong>).</li>
																			<li>Press enter.</li>
																		</ol>
																		<strong>Windows XP</strong>
																		<br />
																		<ol>
																			<li>Press Control + Alt + Delete when prompted.</li>
																			<li>Enter your username (<strong>$EmployeeDTO.Username$</strong>).</li>
																			<li>Enter your password (<strong>$password$</strong>).</li>
																			<li>Select your domain (<strong>$ntdomain$</strong>).</li>
																			<li>Press enter.</li>
																		</ol>
																	</div>
																</td>
															</tr>
														</table>
														<!-- // End Module: Standard Content \\ -->
													</td>
												</tr>
											</table>
											<!-- // End Template Body \\ -->
										</td>
									</tr>
								</table>
								<br />
							</td>
						</tr>
					</table>
				</center>
			</body>
			</html>'
		, CAST(0x00009ED30116A873 AS DateTime), NULL, N'uManage', NULL, 1)

/****** Object:  Table [dbo].[AppSettings]    Script Date: 04/28/2011 22:57:49 ******/
INSERT [dbo].[AppSettings] ([SettingId], [Key], [Value], [IsEncrypted]) VALUES (N'b1aade19-17ec-4cdd-b362-0ade5ede4859', N'AdUser', N'', 0)
INSERT [dbo].[AppSettings] ([SettingId], [Key], [Value], [IsEncrypted]) VALUES (N'8a0a3517-06f2-4c53-9f39-44c1efb1d4bd', N'AppUrl', N'', 0)
INSERT [dbo].[AppSettings] ([SettingId], [Key], [Value], [IsEncrypted]) VALUES (N'd0fdede8-7c40-4b3b-b895-4f561d59c867', N'AdUserPass', N'', 0)
INSERT [dbo].[AppSettings] ([SettingId], [Key], [Value], [IsEncrypted]) VALUES (N'dc2095e0-2f87-47c5-8d49-81720d874744', N'AppTitle', N'Welcome to uManage', 0)
INSERT [dbo].[AppSettings] ([SettingId], [Key], [Value], [IsEncrypted]) VALUES (N'65d302cb-7aea-4af4-b29a-c89111335148', N'AdPath', N'', 0)
INSERT [dbo].[AppSettings] ([SettingId], [Key], [Value], [IsEncrypted]) VALUES (N'9e8d3417-37ce-42d5-b4da-1fa323932bb4', N'GroupsToIgnore', N'SQLServer2005SQLBrowserUser$LIB-IMPORT,SQLServer2005MSSQLServerADHelperUser$LIB-IMPORT,SQLServer2005MSSQLUser$LIB-IMPORT$SQLEXPRESS,SQLServer2005MSSQLUser$LIB-IMPORT$MS_ADMT,SQLServer2005SQLBrowserUser$LIB-SERVER,SQLServer2005MSSQLServerADHelperUser$LIB-SERVER,SQLServer2005MSSQLUser$LIB-SERVER$SQLEXPRESS,SQLServer2005SQLBrowserUser$MIS-TEST,SQLServer2005MSSQLServerADHelperUser$MIS-TEST,SQLServer2005MSSQLUser$MIS-TEST$MS_ADMT,SQLServerMSSQLServerADHelperUser$MIS-TEST', 0)
INSERT [dbo].[AppSettings] ([SettingId], [Key], [Value], [IsEncrypted]) VALUES (N'8A835DC0-1B80-47FE-AB4E-50795AE66E73', N'HomePageEnabled', N'True', 0)
INSERT [dbo].[AppSettings] ([SettingId], [Key], [Value], [IsEncrypted]) VALUES (N'B13BEB47-8AC1-47BA-A988-7BDC8B97DD63', N'HomePageOverride', N'False', 0)
INSERT [dbo].[AppSettings] ([SettingId], [Key], [Value], [IsEncrypted]) VALUES (N'A4B5F0C0-FA6C-4776-B09C-8024D40FC671', N'OrgName', N'uManage', 0)
INSERT [dbo].[AppSettings] ([SettingId], [Key], [Value], [IsEncrypted]) VALUES (N'ACB93EBA-910D-44C3-8DB4-CCDF65BD3A41', N'QuickLinksEnabled', N'True', 0)

/****** Object:  Table [dbo].[Roles]    Script Date: 04/29/2011 16:42:07 ******/
INSERT [dbo].[Roles] ([RoleId], [Name], [Description]) VALUES (N'6391c615-25cc-4131-b9b9-984e043acfa8', N'AdminPortal', N'Admin Portal Access')
INSERT [dbo].[Roles] ([RoleId], [Name], [Description]) VALUES (N'7fa7726b-13e8-4ca3-99cc-bee8389bad13', N'Configuration', N'Application Configuration Access')

/****** Object:  Table [dbo].[Posts]    Script Date: 04/29/2011 16:42:07 ******/
INSERT INTO [dbo].[Posts] ([PostId] ,[Subject] ,[Message] ,[PostedBy] ,[PostedOn] ,[VisibleFrom] ,[VisibileTo]) VALUES (NEWID() ,N'Welcome to uManage!' ,'Congratulations on setting up and configuring uManage!<br /><br />This page is the home page users will use or visit when launching the application.  This wall allows your organization to publish messages for employees to review.<br /><br />Please make sure to visit the uManage home page for more information and configuration instructions at http://umanage.codeplex.com.  Feel free to post issues or ask questions so we can improve the system.<br />Thanks,<br />Team uManage' ,'UMANAGE' ,GETUTCDATE() ,GETUTCDATE() ,GETUTCDATE()+365)

/****** Object:  Table [dbo].[QuickLinks]    Script Date: 04/29/2011 16:42:07 ******/
INSERT INTO [dbo].[QuickLinks] ([LinkId] ,[Url] ,[DisplayText] ,[DisplayOrder]) VALUES (NEWID() ,'http://www.bing.com' ,'Bing' ,1)
INSERT INTO [dbo].[QuickLinks] ([LinkId] ,[Url] ,[DisplayText] ,[DisplayOrder]) VALUES (NEWID() ,'http://www.google.com' ,'Google' ,2)
INSERT INTO [dbo].[QuickLinks] ([LinkId] ,[Url] ,[DisplayText] ,[DisplayOrder]) VALUES (NEWID() ,'http://umanage.codeplex.com' ,'uManage' ,100)