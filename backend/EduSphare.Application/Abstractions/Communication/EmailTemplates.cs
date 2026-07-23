// using System;
// using System.Collections.Generic;
// using System.Text;

// namespace EduSphare.Application.Abstractions.Communication
// {
//     public static class EmailTemplates
//     {
//         private static string BaseLayout(string content) => $"""
//             <!DOCTYPE html>
//             <html lang="en">
//             <head>
//               <meta charset="UTF-8" />
//               <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
//               <title>EduSphare</title>
//             </head>
//             <body style="margin:0;padding:0;background-color:#0f0f1a;font-family:'Segoe UI',Arial,sans-serif;">
//               <table width="100%" cellpadding="0" cellspacing="0" style="background-color:#0f0f1a;padding:40px 0;">
//                 <tr>
//                   <td align="center">
//                     <table width="600" cellpadding="0" cellspacing="0" style="max-width:600px;width:100%;">

//                       <!-- Header -->
//                       <tr>
//                         <td align="center" style="padding-bottom:32px;">
//                           <table cellpadding="0" cellspacing="0">
//                             <tr>
//                               <td style="background:linear-gradient(135deg,#6c63ff,#48c6ef);border-radius:16px;padding:14px 28px;">
//                                 <span style="font-size:24px;font-weight:800;color:#ffffff;letter-spacing:1px;">
//                                   ✦ EduSphare
//                                 </span>
//                               </td>
//                             </tr>
//                           </table>
//                         </td>
//                       </tr>

//                       <!-- Card -->
//                       <tr>
//                         <td style="background:#1a1a2e;border-radius:24px;border:1px solid #2a2a4a;overflow:hidden;">
//                           {content}

//                           <!-- Footer -->
//                           <table width="100%" cellpadding="0" cellspacing="0">
//                             <tr>
//                               <td style="padding:24px 40px;border-top:1px solid #2a2a4a;text-align:center;">
//                                 <p style="margin:0 0 8px 0;font-size:13px;color:#6b6b8a;">
//                                   You're receiving this email because you signed up for EduSphare.
//                                 </p>
//                                 <p style="margin:0;font-size:12px;color:#4a4a6a;">
//                                   © 2025 EduSphare · All rights reserved
//                                 </p>
//                               </td>
//                             </tr>
//                           </table>
//                         </td>
//                       </tr>

//                     </table>
//                   </td>
//                 </tr>
//               </table>
//             </body>
//             </html>
//             """;

//         public static (string Subject, string Body) VerificationCode(string code) =>
//         (
//             "🎓 Verify your EduSphare account",
//             BaseLayout($"""
//                 <!-- Hero Banner -->
//                 <table width="100%" cellpadding="0" cellspacing="0">
//                   <tr>
//                     <td style="background:linear-gradient(135deg,#6c63ff 0%,#3b3b8f 50%,#1a1a2e 100%);padding:48px 40px 40px;text-align:center;">
//                       <div style="font-size:52px;margin-bottom:16px;">🚀</div>
//                       <h1 style="margin:0 0 8px 0;font-size:28px;font-weight:800;color:#ffffff;line-height:1.3;">
//                         Welcome to EduSphare!
//                       </h1>
//                       <p style="margin:0;font-size:16px;color:#c4bfff;font-weight:400;">
//                         You're one step away from unlocking your learning journey.
//                       </p>
//                     </td>
//                   </tr>
//                 </table>

//                 <!-- Body -->
//                 <table width="100%" cellpadding="0" cellspacing="0">
//                   <tr>
//                     <td style="padding:40px 40px 32px;">
//                       <p style="margin:0 0 24px 0;font-size:16px;color:#b0b0cc;line-height:1.6;">
//                         Hey there! 👋 Use the verification code below to confirm your email address and activate your account.
//                       </p>

//                       <!-- Code Box -->
//                       <table width="100%" cellpadding="0" cellspacing="0">
//                         <tr>
//                           <td align="center" style="padding:8px 0 32px;">
//                             <table cellpadding="0" cellspacing="0">
//                               <tr>
//                                 <td style="background:linear-gradient(135deg,#6c63ff,#48c6ef);border-radius:16px;padding:3px;">
//                                   <table cellpadding="0" cellspacing="0">
//                                     <tr>
//                                       <td style="background:#12122a;border-radius:14px;padding:24px 48px;text-align:center;">
//                                         <p style="margin:0 0 6px 0;font-size:11px;font-weight:700;color:#6c63ff;letter-spacing:3px;text-transform:uppercase;">
//                                           Your Verification Code
//                                         </p>
//                                         <p style="margin:0;font-size:42px;font-weight:800;color:#ffffff;letter-spacing:10px;font-family:'Courier New',monospace;">
//                                           {code}
//                                         </p>
//                                       </td>
//                                     </tr>
//                                   </table>
//                                 </td>
//                               </tr>
//                             </table>
//                           </td>
//                         </tr>
//                       </table>

//                       <!-- Warning -->
//                       <table width="100%" cellpadding="0" cellspacing="0">
//                         <tr>
//                           <td style="background:#1e1e3a;border-left:4px solid #f59e0b;border-radius:8px;padding:14px 18px;">
//                             <p style="margin:0;font-size:13px;color:#f59e0b;">
//                               ⏳ This code expires in <strong>10 minutes</strong>. Do not share it with anyone.
//                             </p>
//                           </td>
//                         </tr>
//                       </table>
//                     </td>
//                   </tr>
//                 </table>
//                 """)
//         );

//         public static (string Subject, string Body) PasswordResetCode(string code) =>
//         (
//             "🔐 Reset your EduSphare password",
//             BaseLayout($"""
//                 <!-- Hero Banner -->
//                 <table width="100%" cellpadding="0" cellspacing="0">
//                   <tr>
//                     <td style="background:linear-gradient(135deg,#f43f5e 0%,#7c3aed 50%,#1a1a2e 100%);padding:48px 40px 40px;text-align:center;">
//                       <div style="font-size:52px;margin-bottom:16px;">🔑</div>
//                       <h1 style="margin:0 0 8px 0;font-size:28px;font-weight:800;color:#ffffff;line-height:1.3;">
//                         Password Reset Request
//                       </h1>
//                       <p style="margin:0;font-size:16px;color:#fecdd3;font-weight:400;">
//                         We received a request to reset your EduSphare password.
//                       </p>
//                     </td>
//                   </tr>
//                 </table>

//                 <!-- Body -->
//                 <table width="100%" cellpadding="0" cellspacing="0">
//                   <tr>
//                     <td style="padding:40px 40px 32px;">
//                       <p style="margin:0 0 24px 0;font-size:16px;color:#b0b0cc;line-height:1.6;">
//                         No worries, it happens to everyone! 😄 Use the code below to reset your password and get back to learning.
//                       </p>

//                       <!-- Code Box -->
//                       <table width="100%" cellpadding="0" cellspacing="0">
//                         <tr>
//                           <td align="center" style="padding:8px 0 32px;">
//                             <table cellpadding="0" cellspacing="0">
//                               <tr>
//                                 <td style="background:linear-gradient(135deg,#f43f5e,#7c3aed);border-radius:16px;padding:3px;">
//                                   <table cellpadding="0" cellspacing="0">
//                                     <tr>
//                                       <td style="background:#12122a;border-radius:14px;padding:24px 48px;text-align:center;">
//                                         <p style="margin:0 0 6px 0;font-size:11px;font-weight:700;color:#f43f5e;letter-spacing:3px;text-transform:uppercase;">
//                                           Your Reset Code
//                                         </p>
//                                         <p style="margin:0;font-size:42px;font-weight:800;color:#ffffff;letter-spacing:10px;font-family:'Courier New',monospace;">
//                                           {code}
//                                         </p>
//                                       </td>
//                                     </tr>
//                                   </table>
//                                 </td>
//                               </tr>
//                             </table>
//                           </td>
//                         </tr>
//                       </table>

//                       <!-- Warning -->
//                       <table width="100%" cellpadding="0" cellspacing="0">
//                         <tr>
//                           <td style="background:#1e1e3a;border-left:4px solid #f59e0b;border-radius:8px;padding:14px 18px;margin-bottom:16px;">
//                             <p style="margin:0;font-size:13px;color:#f59e0b;">
//                               ⏳ This code expires in <strong>10 minutes</strong>. Do not share it with anyone.
//                             </p>
//                           </td>
//                         </tr>
//                         <tr><td style="height:12px;"></td></tr>
//                         <tr>
//                           <td style="background:#1e1e3a;border-left:4px solid #ef4444;border-radius:8px;padding:14px 18px;">
//                             <p style="margin:0;font-size:13px;color:#fca5a5;">
//                               🚫 If you didn't request this, you can safely ignore this email. Your account is secure.
//                             </p>
//                           </td>
//                         </tr>
//                       </table>
//                     </td>
//                   </tr>
//                 </table>
//                 """)
//         );
//     }
// }

using System;

namespace EduSphare.Application.Abstractions.Communication
{
    public static class EmailTemplates
    {
        private const string Bg        = "#f4f5f7"; // page background
        private const string Surface   = "#ffffff"; // card
        private const string Ink       = "#1c2333"; // primary text
        private const string Muted     = "#5b6474"; // secondary text
        private const string Faint     = "#9aa1ae"; // footer text
        private const string Line      = "#e7e9ee"; // borders
        private const string Accent    = "#4f5bd5"; // brand indigo
        private const string AccentSoft= "#eef0fc"; // accent tint

        private static string BaseLayout(string content, string preheader) => $"""
            <!DOCTYPE html>
            <html lang="en">
            <head>
              <meta charset="UTF-8" />
              <meta name="viewport" content="width=device-width, initial-scale=1.0" />
              <title>EduSphare</title>
            </head>
            <body style="margin:0;padding:0;background-color:{Bg};font-family:-apple-system,'Segoe UI',Roboto,Helvetica,Arial,sans-serif;">
              <span style="display:none;max-height:0;overflow:hidden;opacity:0;color:{Bg};">{preheader}</span>
              <table role="presentation" width="100%" cellpadding="0" cellspacing="0" style="background-color:{Bg};padding:48px 16px;">
                <tr>
                  <td align="center">
                    <table role="presentation" width="560" cellpadding="0" cellspacing="0" style="max-width:560px;width:100%;">

                      <!-- Brand -->
                      <tr>
                        <td style="padding:0 4px 24px;">
                          <span style="font-size:19px;font-weight:700;color:{Ink};letter-spacing:-0.2px;">EduSphare</span>
                        </td>
                      </tr>

                      <!-- Card -->
                      <tr>
                        <td style="background:{Surface};border:1px solid {Line};border-radius:16px;">
                          {content}
                        </td>
                      </tr>

                      <!-- Footer -->
                      <tr>
                        <td style="padding:24px 8px 0;text-align:center;">
                          <p style="margin:0 0 6px;font-size:13px;color:{Faint};line-height:1.6;">
                            You received this email because an EduSphare account is associated with your address.
                          </p>
                          <p style="margin:0;font-size:12px;color:{Faint};">
                            © 2026 EduSphare · All rights reserved
                          </p>
                        </td>
                      </tr>

                    </table>
                  </td>
                </tr>
              </table>
            </body>
            </html>
            """;

        // Shared code block so both emails stay visually consistent
        private static string CodeBlock(string label, string code) => $"""
            <table role="presentation" width="100%" cellpadding="0" cellspacing="0">
              <tr>
                <td align="center" style="padding:8px 0 4px;">
                  <table role="presentation" cellpadding="0" cellspacing="0" style="background:{AccentSoft};border:1px solid #dfe3fb;border-radius:12px;">
                    <tr>
                      <td style="padding:22px 44px;text-align:center;">
                        <p style="margin:0 0 8px;font-size:11px;font-weight:600;color:{Accent};letter-spacing:1.5px;text-transform:uppercase;">
                          {label}
                        </p>
                        <p style="margin:0;font-size:34px;font-weight:700;color:{Ink};letter-spacing:8px;font-family:'SFMono-Regular',Consolas,'Courier New',monospace;">
                          {code}
                        </p>
                      </td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table>
            """;

        public static (string Subject, string Body) VerificationCode(string code) =>
        (
            "Confirm your EduSphare email address",
            BaseLayout($"""
                <table role="presentation" width="100%" cellpadding="0" cellspacing="0">
                  <tr>
                    <td style="padding:40px 40px 8px;">
                      <h1 style="margin:0 0 14px;font-size:22px;font-weight:700;color:{Ink};line-height:1.35;letter-spacing:-0.3px;">
                        Confirm your email address
                      </h1>
                      <p style="margin:0 0 28px;font-size:15px;color:{Muted};line-height:1.65;">
                        Welcome to EduSphare. Enter the code below to verify your address and finish setting up your account.
                      </p>
                    </td>
                  </tr>
                  <tr>
                    <td style="padding:0 40px;">
                      {CodeBlock("Verification code", code)}
                    </td>
                  </tr>
                  <tr>
                    <td style="padding:24px 40px 40px;">
                      <p style="margin:0;font-size:13px;color:{Faint};line-height:1.6;border-top:1px solid {Line};padding-top:20px;">
                        This code is valid for 10 minutes. If you didn't create an EduSphare account, you can safely ignore this email.
                      </p>
                    </td>
                  </tr>
                </table>
                """,
                "Your EduSphare verification code")
        );

        public static (string Subject, string Body) PasswordResetCode(string code) =>
        (
            "Reset your EduSphare password",
            BaseLayout($"""
                <table role="presentation" width="100%" cellpadding="0" cellspacing="0">
                  <tr>
                    <td style="padding:40px 40px 8px;">
                      <h1 style="margin:0 0 14px;font-size:22px;font-weight:700;color:{Ink};line-height:1.35;letter-spacing:-0.3px;">
                        Reset your password
                      </h1>
                      <p style="margin:0 0 28px;font-size:15px;color:{Muted};line-height:1.65;">
                        We received a request to reset the password for your EduSphare account. Use the code below to choose a new one.
                      </p>
                    </td>
                  </tr>
                  <tr>
                    <td style="padding:0 40px;">
                      {CodeBlock("Reset code", code)}
                    </td>
                  </tr>
                  <tr>
                    <td style="padding:24px 40px 40px;">
                      <p style="margin:0;font-size:13px;color:{Faint};line-height:1.6;border-top:1px solid {Line};padding-top:20px;">
                        This code is valid for 10 minutes. If you didn't request a password reset, no action is needed — your account remains secure.
                      </p>
                    </td>
                  </tr>
                </table>
                """,
                "Your EduSphare password reset code")
        );
    }
}