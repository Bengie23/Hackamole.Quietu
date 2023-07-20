﻿using Hackamole.Quietu.Domain.Entities;
using static Confluent.Kafka.ConfigPropertyNames;

namespace Hackamole.Quietu.Data
{
    public  class QuietuSeeder
    {
        private QuietuDbContext DbContext;

        public QuietuSeeder(QuietuDbContext dbContext) 
        {
            this.DbContext = dbContext;
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
        }

        public void Seed()
        {
            string[] productCodes = { "PRODUCT_GROUP_SOLVER_ENGINE", "PRODUCT_GROUP_SCHEDULING_METRICS", "PRODUCT_ACCOUNT_REFERRAL_TOOL", "PRODUCT_ACCOUNT_CONNECT_MDS", "PRODUCT_GROUP_ABSENCES_RESTRICTION_KIND", "PRODUCT_GROUP_MANAGE_MEMBERS", "PRODUCT_GROUP_OPTIMIZED_TOKENBAR", "PRODUCT_GROUP_MANDRILL_ACTIVATION", "PRODUCT_ACCOUNT_FAST_CALENDAR", "PRODUCT_GROUP_SMART_APP_BANNER", "PRODUCT_ACCOUNT_API_ACCESS", "PRODUCT_ACCOUNT_MANDRILL_EMAILS", "PRODUCT_GROUP_EP_MULTI_SOURCE_ENGINE", "PRODUCT_ACCOUNT_ABSENCE_ENTRY", "PRODUCT_ACCOUNT_COMMUNITY_GROUP", "PRODUCT_GROUP_PLANNING_RESOURCE_SELECTOR", "PRODUCT_GROUP_EQUITY_DISTRIBUTION_MANAGER", "PRODUCT_GROUP_PEOPLE_BAR", "PRODUCT_ACCOUNT_SLA", "PRODUCT_GROUP_SCHEDULE_INELIGIBILITY_DATES", "PRODUCT_GROUP_PEOPLE_BOX_SEARCH", "PRODUCT_GROUP_CME_EVENTS", "PRODUCT_GROUP_STEP_EXECUTE_SIDEKIQ", "PRODUCT_GROUP_CAPRICA_SCHEDULE_TOOL", "PRODUCT_GROUP_FALL_RELEASE", "PRODUCT_GROUP_SCHEDULE_INELIGIBILITY_SELF_SERVICE", "PRODUCT_GROUP_ABSENCE_BANNER", "PRODUCT_ACCOUNT_EREP", "PRODUCT_ACCOUNT_EREP_MARKETING", "PRODUCT_GROUP_LATE_TO_PUBLISH_NOTIFY", "PRODUCT_GROUP_NOTIFICATIONS_SCHEDULE_TOOL", "PRODUCT_GROUP_ABSENCE_DASHBOARD", "PRODUCT_GROUP_MARKETPLACE", "PRODUCT_GROUP_SOLVER_MODEL_CACHE", "PRODUCT_GROUP_CAPRICA_ANALYZE", "PRODUCT_GROUP_SPLIT_SHIFT", "PRODUCT_ACCOUNT_NOTIFICATION_DELIVERY", "PRODUCT_ACCOUNT_FORGOT_PASSWORD_TEMPLATE", "PRODUCT_GROUP_FOUR_WEEKS_TASKS", "PRODUCT_ACCOUNT_ZENDESK_DEFLECTION", "PRODUCT_GROUP_SCOVILLE", "PRODUCT_GROUP_DELETE_RESOURCE", "PRODUCT_GROUP_AUTO_DELETE_RESOURCES", "PRODUCT_GROUP_EDUCATION_PROMO_BANNER", "PRODUCT_GROUP_EDIT_RESOURCE", "PRODUCT_GROUP_ANALYTICS", "PRODUCT_GROUP_HEURISTIC_SOLVER", "PRODUCT_ACCOUNT_PHONE_NUMBER_PRIORITY", "PRODUCT_GROUP_ADD_RESOURCE", "PRODUCT_GROUP_GREEDY_SOLVER", "PRODUCT_GROUP_MEMBERS_LIST", "PRODUCT_GROUP_MANAGE_RESOURCES", "PRODUCT_GROUP_CHANGE_REQUEST_ASSIGN_TO", "PRODUCT_GROUP_PUBLIC_CONSOLE", "PRODUCT_ACCOUNT_WEBSITE", "PRODUCT_ACCOUNT_SCOVILLE_CONNECT", "PRODUCT_ACCOUNT_SCOVILLE_CREATE_GROUP", "PRODUCT_ACCOUNT_SCOVILLE_GROUP_DETAILS", "PRODUCT_GROUP_SCOVILLE_GROUP_UPGRADE", "PRODUCT_ACCOUNT_SCOVILLE_CALENDARS", "PRODUCT_ACCOUNT_SCOVILLE_CONTACTS", "PRODUCT_ACCOUNT_SCOVILLE_DOCUMENTS", "PRODUCT_ACCOUNT_SCOVILLE_EDUCATION", "PRODUCT_ACCOUNT_SCOVILLE_HELP", "PRODUCT_ACCOUNT_SCOVILLE_PROFILE", "PRODUCT_ACCOUNT_SCOVILLE_NOTIFICATIONS", "PRODUCT_ACCOUNT_SCOVILLE_GLOBAL_SEARCH", "PRODUCT_ACCOUNT_SCOVILLE_INBOX_SORT", "PRODUCT_ACCOUNT_SCOVILLE_GROUP_AVATAR_CROPPER", "PRODUCT_ACCOUNT_SCOVILLE_LEAVE_GROUP", "PRODUCT_ACCOUNT_SCOVILLE_INBOX_ADD_PARTICIPANT", "PRODUCT_ACCOUNT_SCOVILLE_INBOX_MARK_AS_READ", "PRODUCT_ACCOUNT_SCOVILLE_INBOX_FLAG_MESSAGE", "PRODUCT_ACCOUNT_SCOVILLE_EDIT_GROUP", "PRODUCT_ACCOUNT_ZENDESK_REDIRECT", "PRODUCT_ACCOUNT_SCOVILLE_INBOX_SEARCH", "PRODUCT_ACCOUNT_SCOVILLE_EDIT_GROUP_DETAILS", "PRODUCT_ACCOUNT_SCOVILLE_EDIT_GROUP_AVATAR", "PRODUCT_ACCOUNT_SCOVILLE_EDIT_GROUP_ADMINS", "PRODUCT_GROUP_SCOVILLE_SCHEDULE_TOOL", "PRODUCT_ACCOUNT_SUMMARY_DIGEST", "PRODUCT_ACCOUNT_PREVENT_REOPEN_SUPPORT_MESSAGE", "PRODUCT_GROUP_SCHEDULE_CONSTRAINT_ACQUISITION", "PRODUCT_GROUP_PATIENT_SCHEDULING", "PRODUCT_GROUP_SCOVILLE_PERIOD_LIST", "PRODUCT_GROUP_PATIENT_LOGIN", "PRODUCT_ACCOUNT_CONNECT_PLATFORM", "PRODUCT_GROUP_STEP_HUMANIZER_EVENT_NAME", "PRODUCT_GROUP_SCHEDULE_TOOL_PROMO_BANNER", "PRODUCT_GROUP_SCHEDULE_TOOL_PROMO_DOCUMENT", "PRODUCT_GROUP_MARKETPLACE_NEW_OFFER_NOTIFICATION", "PRODUCT_GROUP_SCHEDULE_REPORT_EXPORT_BY_RESOURCE", "PRODUCT_GROUP_SCHEDULE_REPORT_PRINT_ASSIGNMENTS", "PRODUCT_GROUP_SCHEDULE_REPORT_ADVANCED_EQUITY", "PRODUCT_GROUP_SCHEDULE_TOOL_HORIZONTAL_STICK", "PRODUCT_GROUP_SCHEDULE_TOOL_VERTICAL_STICK", "PRODUCT_ACCOUNT_AGILE_TOUR_WEBPAGE", "PRODUCT_GROUP_PERIOD_VERSIONING", "PRODUCT_GROUP_ABSENCE_LIMITS", "PRODUCT_GROUP_SPLIT_PLANNER", "PRODUCT_GROUP_SPLIT_TRANSFERS", "PRODUCT_GROUP_EQUITY_LIMITING", "PRODUCT_GROUP_TEACHING_LINKS", "PRODUCT_GROUP_TEAMS", "PRODUCT_GROUP_SUBSETS", "PRODUCT_GROUP_CUSTOM_MOMENTS", "PRODUCT_GROUP_CONSTRAINTS", "PRODUCT_GROUP_DAILY_BLOCKING", "PRODUCT_GROUP_BLOCKING", "PRODUCT_GROUP_SCRIPT", "PRODUCT_GROUP_DAILY_TARGET", "PRODUCT_GROUP_MULTI_DAY_BLOCKS", "PRODUCT_GROUP_MULTI_PERIOD_EQUITY_REPORT", "PRODUCT_GROUP_TEMPLATES", "PRODUCT_GROUP_ROTATIONS", "PRODUCT_GROUP_CALENDAR_SUBSCRIPTION", "PRODUCT_ACCOUNT_MEETING_NOTIFICATIONS", "PRODUCT_GROUP_WEIGHT_TOLERANCE_EQUITY_PACKS", "PRODUCT_GROUP_BUTTON_ADJUST_DATES_EQUITY_PACKS", "PRODUCT_GROUP_BUTTON_NEW_EQUITY_PACKS", "PRODUCT_GROUP_AVANCED_EQUITY_PACKS_OPTIONS", "PRODUCT_GROUP_PATIENT_APPOINTMENT_CONFIRMATION", "PRODUCT_GROUP_PATIENT_APPOINTMENT_REMINDER", "PRODUCT_GROUP_SHOW_ALL_OPTIONS_MODAL_EDIT_TASK", "PRODUCT_GROUP_SHOW_ALL_REPORT", "PRODUCT_GROUP_SHOW_ALL_CONTEXT_LINKS", "PRODUCT_GROUP_ACTIVATE_HEAD_LINKS_EQUITY_INSPECTOR", "PRODUCT_GROUP_SHOW_LINK_RESOURCE_EQUITY_INSPECTOR", "PRODUCT_GROUP_SHOW_LINK_CONTEXT_SELECTOR_SCRIPT", "PRODUCT_GROUP_SHOW_LINK_CONTEXT_SELECTOR_EQUITY", "PRODUCT_GROUP_SHOW_EQUITY_COLUMN_ASSIGNMENT", "PRODUCT_GROUP_SHOW_PROBLEMS_COLUMN_ASSIGNMENT", "PRODUCT_GROUP_SHOW_EDIT_COLUMN_ASSIGNMENT", "PRODUCT_GROUP_SHOW_ALL_AXIS_VIEW", "PRODUCT_GROUP_SHOW_ALL_FILTERS_TOOLBAR", "PRODUCT_GROUP_PATIENT_APPOINTMENT_CANCELLATION", "PRODUCT_GROUP_SHOW_LINK_SPANS_MENU", "PRODUCT_GROUP_SHOW_FEATURES_TASK_KIND_GRID", "PRODUCT_GROUP_SHOW_DATE_RANGE_EQUITY_PACK", "PRODUCT_GROUP_SHOW_TRANSFER_APPROVAL_MOMENT", "PRODUCT_GROUP_SHOW_LINK_TRANSFER_NOTIFICATIONS", "PRODUCT_GROUP_SHOW_LINK_LAYOUT", "PRODUCT_GROUP_SHOW_LINK_HELPER_ROWS", "PRODUCT_GROUP_SHOW_CONSTRAINTS_SEMIAUTO", "PRODUCT_GROUP_SHOW_CONSTRAINTS_AUTO", "PRODUCT_GROUP_SHOW_CONSTRAINTS_AUTOTEAM", "PRODUCT_GROUP_SHOW_CONSTRAINT_WEEKLY_PROTECTION", "PRODUCT_GROUP_SHOW_MEMBERS_DATES", "PRODUCT_GROUP_SHOW_LINK_INELIGIBILITY_DATE_RANGE", "PRODUCT_GROUP_SHOW_LINK_HOLIDAYS", "PRODUCT_GROUP_SHOW_NON_AVAILABILITY_MAPPING", "PRODUCT_GROUP_SHOW_LINK_REPORTS", "PRODUCT_GROUP_SHOW_LINK_ABSENCES_REPORTS", "PRODUCT_GROUP_SHOW_ABSENCES_PERMISSIONS", "PRODUCT_GROUP_PATIENT_PERIOD_OPENING", "PRODUCT_GROUP_SHOW_BUTTON_PRINT_ABSENCE", "PRODUCT_GROUP_SHOW_MODIFY_DATES", "PRODUCT_GROUP_SHOW_BY_TASKS_FOUR_WEEKS", "PRODUCT_GROUP_SHOW_FILTERS_TASKS_VIEW", "PRODUCT_GROUP_PATIENT_SHOW_PAST_AVAILABILITIES", "PRODUCT_GROUP_NOTIFICATIONS_PRIVACY", "PRODUCT_ACCOUNT_DEPRECATE_JQUERY_IOS", "PRODUCT_GROUP_PETAL_WEB", "PRODUCT_GROUP_MOBILE_CONSOLE", "PRODUCT_GROUP_PATIENT_WALKIN", "PRODUCT_GROUP_PATIENT_ASSISTANT_PHR", "PRODUCT_GROUP_DOCUMENT_CREATE_AND_DELETE", "PRODUCT_ACCOUNT_MOBILE_PROFILE", "PRODUCT_ACCOUNT_MOBILE_CONSOLE", "PRODUCT_GROUP_HIDE_LEGACY_ICON", "PRODUCT_GROUP_STATIC_PRODUCT_AWARENESS", "PRODUCT_GROUP_PATIENT_PHONE_BOOKING", "PRODUCT_GROUP_PATIENT_PHONE_REMINDERS", "PRODUCT_GROUP_SCHEDULE_MANAGEMENT", "PRODUCT_GROUP_POSITIVE_PREFERENCE", "PRODUCT_GROUP_NOTIFICATIONS_PRIVACY_ENHANCEMENT", "PRODUCT_GROUP_CALENDAR_FILTERS", "PRODUCT_GROUP_PATIENT_EMR_HIN_FALLBACK", "PRODUCT_GROUP_OPTIMIZE_SPREAD", "PRODUCT_GROUP_CALENDAR_EVENT_EDIT", "PRODUCT_GROUP_CALENDAR_DAILY_VIEW", "PRODUCT_GROUP_PATIENT_EXT_AVAIL_MANAGER", "PRODUCT_GROUP_CONSOLE_CONTACTS", "PRODUCT_GROUP_CALENDAR_MOBILE_APIV2", "PRODUCT_GROUP_PATIENT_APPOINTMENT_NOTE", "PRODUCT_GROUP_PATIENT_BILLING_LINK", "PRODUCT_GROUP_CALENDAR_ABSENCE_DETAIL", "PRODUCT_GROUP_CALENDAR_TASK_REQUESTS_DETAIL", "PRODUCT_GROUP_PATIENT_DASHBOARD_DAILY_MODE", "PRODUCT_GROUP_ADD_ABSENCES", "PRODUCT_ACCOUNT_DEPRECATE_PERSONAL_EVENTS", "PRODUCT_GROUP_SIMPLE_SPREAD", "PRODUCT_GROUP_PATIENT_EXTRA_APPT_INFO", "PRODUCT_GROUP_SCHEDULE_ADD_TASK_PERSONAL_CALENDAR", "PRODUCT_GROUP_PATIENT_MEDICAL_NOTES", "PRODUCT_GROUP_TRANSFER_EXCHANGE_WEB", "PRODUCT_GROUP_PATIENT_SELF_REGISTER_EMR_FALLBACK", "PRODUCT_GROUP_CALENDAR_GROUP_CALENDAR", "PRODUCT_GROUP_CALENDAR_DASHBOARD", "PRODUCT_GROUP_CALENDAR_DASHBOARD_WEEKLY_VIEW", "PRODUCT_GROUP_CALENDAR_TASK_WEEKLY_VIEW", "PRODUCT_GROUP_CALENDAR_PHYSICIAN_WEEKLY_VIEW", "PRODUCT_GROUP_CALENDAR_PHYSICIAN_MONTHLY_VIEW", "PRODUCT_GROUP_PATIENT_DAILY_APPOINTMENT_SYNC", "PRODUCT_GROUP_PATIENT_DAILY_APPOINTMENT_REMOVAL", "PRODUCT_GROUP_PATIENT_SURROGATE", "PRODUCT_GROUP_PATIENT_EMR_REMINDER_CHECK", "PRODUCT_GROUP_PATIENT_ONLY_SYNC_WEB_AVAILABILITIES", "PRODUCT_GROUP_PATIENT_DIRECT_APPOINTMENT_EXPORT", "PRODUCT_GROUP_PATIENT_DAILY_SYNC", "PRODUCT_GROUP_PATIENT_EMR_AVAIL_DOUBLE_CHECK", "PRODUCT_GROUP_PATIENT_PROFILE_SYNC_TO_EMR", "PRODUCT_GROUP_PATIENT_DASHBOARD_RIGHT_CLICK", "PRODUCT_GROUP_SCHEDULE_TOOL_STEP_SCRIPT_UNDO", "PRODUCT_GROUP_QUADRATIC_EQUITY", "PRODUCT_GROUP_MARKETPLACE_UPSELL", "PRODUCT_ACCOUNT_LEAVE_FEEDBACK", "PRODUCT_ACCOUNT_PETAL_WEB_2016_BANNER", "PRODUCT_GROUP_PATIENT_FAMILY_DOCTOR_RATIO", "PRODUCT_GROUP_PATIENT_SMS_REMINDERS", "PRODUCT_GROUP_PATIENT_REMINDER_INDICATOR", "PRODUCT_GROUP_PATIENT_NOTIFICATION_PREFERENCE", "PRODUCT_GROUP_MESSAGING_DASHBOARD", "PRODUCT_GROUP_ADVANCED_EQUITY_PACK_DIAGNOSTIC", "PRODUCT_ACCOUNT_MOBILE_MARKETPLACE", "PRODUCT_GROUP_PATIENT_CLINIC_SELF_SERVICE", "PRODUCT_GROUP_SHOW_LINK_CONTEXT_SELECTOR_AVAIL", "PRODUCT_GROUP_SHOW_LINK_CONTEXT_SELECTOR_TASK", "PRODUCT_GROUP_SHOW_TOOL_FILTER", "PRODUCT_GROUP_SHOW_TOOL_REPORT", "PRODUCT_ACCOUNT_PATIENT_TRIAL", "PRODUCT_ACCOUNT_SCHEDULE_TRIAL", "PRODUCT_ACCOUNT_COMMUNITY_ACCESS_WEB", "PRODUCT_ACCOUNT_COMMUNITY_ACCESS_MOBILE", "PRODUCT_ACCOUNT_COMMUNITY_CAN_POST", "PRODUCT_GROUP_PATIENT_IMPORT_SELF_SERVICE", "PRODUCT_GROUP_PATIENT_TRIAL_INFO", "PRODUCT_GROUP_CONSOLE_ASSISTANT_NOTES", "PRODUCT_ACCOUNT_COMMUNITY_CAN_INVITE", "PRODUCT_ACCOUNT_MANAGE_COMMUNITY", "PRODUCT_GROUP_PATIENT_LIGHTBOX", "PRODUCT_GROUP_PATIENT_SELF_SERVICE_REMINDER", "PRODUCT_GROUP_PATIENT_SMS_CANCEL", "PRODUCT_GROUP_PATIENT_SELF_SERVICE_SERVICE_DETAILS", "PRODUCT_ACCOUNT_COMMUNITY_WEB_CAN_POST", "PRODUCT_GROUP_SCHEDULE_MANAGE_REQUESTS", "PRODUCT_GROUP_PATIENT_SMS_CONFIRM", "PRODUCT_GROUP_PATIENT_DIRECT_PATIENT_AGREEMENT", "PRODUCT_GROUP_PATIENT_STATUS_SELF_SERVICE", "PRODUCT_GROUP_PATIENT_APPOINTMENT_STATUS", "PRODUCT_GROUP_PATIENT_DISABLE_PATIENT", "PRODUCT_GROUP_PATIENT_REMINDER_ATTACHMENTS", "PRODUCT_GROUP_PATIENT_PHONE_CONFIRM", "PRODUCT_GROUP_PATIENT_CUSTOMIZABLE_REMINDER_TEXT", "PRODUCT_GROUP_PATIENT_PHONE_CANCEL", "PRODUCT_GROUP_SCHEDULING_CREATE_ABSENCE", "PRODUCT_GROUP_SCHED_ADM_MANAGE_TASK_GRID", "PRODUCT_GROUP_PATIENT_CANCEL_TIME_LIMIT", "PRODUCT_GROUP_PATIENT_CREATION_ON_LINK", "PRODUCT_GROUP_PATIENT_KNOWN_ALLERGIES_AND_DISEASES", "PRODUCT_GROUP_PATIENT_FORMS", "PRODUCT_GROUP_PATIENT_DASHBOARD_LIST_VIEW", "PRODUCT_GROUP_SYNC_EXTERNAL_CALENDAR", "PRODUCT_GROUP_PATIENT_UPDATE_CONFIRMATION_EMR", "PRODUCT_GROUP_PATIENT_APPOINTMENT_REQUESTS", "PRODUCT_GROUP_PATIENT_GMF_ONLY_ACCOUNT_TASKS", "PRODUCT_GROUP_PATIENT_RECALL_LIST", "PRODUCT_GROUP_SCHEDULE_MANAGE_ABSENCES", "PRODUCT_GROUP_PATIENT_UPDATE_INFORMATION", "PRODUCT_GROUP_PATIENT_RECALL_LIST_REMINDERS", "PRODUCT_GROUP_CALENDAR_MY_REQUESTS", "PRODUCT_GROUP_PATIENT_TASK_AUTO_PUBLISH", "PRODUCT_GROUP_STRIPE", "PRODUCT_GROUP_HOSPITAL_BOOKING", "PRODUCT_GROUP_PETALWEB_SPLIT", "PRODUCT_GROUP_MASS_SHIFTS", "PRODUCT_GROUP_MANAGE_GROUP_MEMBERSHIPS", "PRODUCT_GROUP_MONTHLY_GROUP_CALENDAR", "PRODUCT_GROUP_LANDING_PAGE", "PRODUCT_GROUP_PATIENT_AUTHORIZED_PROFESSIONALS", "PRODUCT_GROUP_PATIENT_REGISTER_DELEGATION_FORM", "PRODUCT_GROUP_SHIFT_TRADE", "PRODUCT_GROUP_ADMIN_FULL_TRANSFER_GRID", "PRODUCT_GROUP_PATIENT_ANALYTICS", "PRODUCT_GROUP_ANALYTICS_APPOINTMENTS_OPTIMIZATION", "PRODUCT_GROUP_ANALYTICS_PATIENTS", "PRODUCT_GROUP_HOSPITAL_ANALYTICS", "PRODUCT_GROUP_PATIENT_ARRIVAL_KIOSK", "PRODUCT_GROUP_GROUP_CALENDAR_MASS_SHIFTS", "PRODUCT_GROUP_MEMBERSHIP_CHANGES_ZENDESK", "PRODUCT_GROUP_PATIENT_CLINIC_OVERFLOW", "PRODUCT_GROUP_ABSENCE_MANAGEMENT_PERMISSIONS", "PRODUCT_GROUP_GROUP_CALENDAR_MASS_ABSENCES", "PRODUCT_GROUP_CREATE_NONSCHEDULED_GROUPS", "PRODUCT_GROUP_HOSPITAL_PHONE_REGISTRY", "PRODUCT_ACCOUNT_ATOA_VIDEO_CONFERENCE", "PRODUCT_GROUP_NEW_PERIOD_LIST", "PRODUCT_GROUP_NEW_SCHEDULE_TOOL", "PRODUCT_GROUP_PATIENT_WAITING_ROOM", "PRODUCT_GROUP_SCHEDULE_GROUP_SETTINGS", "PRODUCT_GROUP_SCHEDULE_SKILLS", "PRODUCT_GROUP_SHIFTS_MANAGEMENT", "PRODUCT_GROUP_NEW_INBOX", "PRODUCT_GROUP_UMF_EXCEL_EXPORT", "PRODUCT_GROUP_HOSPITAL_ANALYTICS_OVERVIEW", "PRODUCT_GROUP_HOSPITAL_ANALYTICS_ACTIVITY", "PRODUCT_GROUP_HOSPITAL_ANALYTICS_COVERAGE", "PRODUCT_GROUP_HOSPITAL_ANALYTICS_WORKLOAD", "PRODUCT_GROUP_HOSPITAL_ANALYTICS_AVAILABILITY", "PRODUCT_GROUP_HOSPITAL_ANALYTICS_PERFORMANCE", "PRODUCT_GROUP_HOSPITAL_ANALYTICS_SAVINGS", "PRODUCT_GROUP_SELF_SERVICE_BLOCKINGS", "PRODUCT_GROUP_PATIENT_SEPARATE_FROM_APP", "PRODUCT_GROUP_SKILLS_TEAMS_MANAGEMENT", "PRODUCT_GROUP_CONSOLE_ONCALL_NOW", "PRODUCT_GROUP_GROUP_CALENDAR_PRINT_MODAL", "PRODUCT_GROUP_ABSENCES_BY_TIME_SLOTS", "PRODUCT_GROUP_NEW_CONSOLE_IP", "PRODUCT_GROUP_MANAGE_GROUP_CONSOLE_MEMBERSHIPS", "PRODUCT_GROUP_FORWARD_MESSAGE", "PRODUCT_GROUP_RIGID_TEACHING_LINKS", "PRODUCT_GROUP_MESSAGE_READ_STATUS", "PRODUCT_GROUP_MESSAGE_READ_CONFIRMATION", "PRODUCT_GROUP_CONSOLE_EDIT_ASSIGNMENTS", "PRODUCT_GROUP_GROUP_CALENDAR_DEFAULT_FILTERS", "PRODUCT_ACCOUNT_MESSAGE_TRASH_BIN", "PRODUCT_GROUP_CATEGORY_PREFERENCE", "PRODUCT_GROUP_HOSPITAL_DASHBOARD_ABSENCES", "PRODUCT_GROUP_PROMO_BILLING", "PRODUCT_GROUP_CHARGEBEE", "PRODUCT_GROUP_MESSAGES_FOLDERS", "PRODUCT_GROUP_MESSAGES_INBOX_FOLDER", "PRODUCT_GROUP_MESSAGES_TAGS", "PRODUCT_ACCOUNT_MESSAGES_INBOX_FOLDER", "PRODUCT_GROUP_CONSOLE_PLANNER_LIST", "PRODUCT_GROUP_MASS_SHIFTS_TRANSFER", "PRODUCT_GROUP_CONSOLE_CONFIGURATION", "PRODUCT_GROUP_EVENT_BILLING_FIELDS", "PRODUCT_GROUP_MESSAGING_CHAT", "PRODUCT_GROUP_DISABLE_SHIFT_AND_BLOCKING_SECTIONS", "PRODUCT_GROUP_MULTI_OFFERS", "PRODUCT_GROUP_MESSAGING_HOSPITAL", "PRODUCT_GROUP_CHARGEBEE_PAYMENT_PAGE", "PRODUCT_GROUP_SSO", "PRODUCT_GROUP_NEW_PROFILE", "PRODUCT_GROUP_MESSAGING", "PRODUCT_GROUP_CHARGEBEE_BILLING_OTHER_ACCOUNTS", "PRODUCT_GROUP_UNRESTRICTED_PROPOSITIONS", "PRODUCT_GROUP_WEB_IP_WHITELIST", "PRODUCT_GROUP_PUBLIC_CONSOLE_IP", "PRODUCT_GROUP_NEW_LAYOUT", "PRODUCT_GROUP_CHAT_EXPORT_PDF", "PRODUCT_GROUP_CHAT_HIDDEN_ACTION", "PRODUCT_GROUP_PHONE_NUMBERS_STANDARDIZATION", "PRODUCT_GROUP_COMM_RICH_TEXT", "PRODUCT_GROUP_SEARCH_IN_CONVERSATION", "PRODUCT_GROUP_PATIENT_OMNIMED_TWO_WAYS_SYNC", "PRODUCT_GROUP_FORWARD_REPLY_ALL", "PRODUCT_GROUP_HOSPITAL_NEW_PHONE_REGISTRY", "PRODUCT_GROUP_HOSPITAL_CONTACT_PHONE_REGISTRY", "PRODUCT_GROUP_HOSPITAL_REMOTE_TASK", "PRODUCT_GROUP_HOSPITAL_MDAVAILABILITY", "PRODUCT_GROUP_HIDE_OLD_LINES", "PRODUCT_GROUP_CHAT_AUDIO_RECORD", "PRODUCT_GROUP_PRINT_CONSOLE_ADD_FIRST_NAME", "PRODUCT_GROUP_PATIENT_REMINDER_PHONE_CUSTOM_TEXT", "PRODUCT_GROUP_MANAGE_SENIORITY", "PRODUCT_GROUP_SENIORITY_SCRIPTS", "PRODUCT_GROUP_NEW_LOGIN", "PRODUCT_GROUP_BOOKING_HUB", "PRODUCT_ACCOUNT_LOOKER_EMBED", "PRODUCT_GROUP_CALENDAR_CHANGE_OWNER", "PRODUCT_GROUP_CALENDAR_INITIATE_CONVOCATION", "PRODUCT_GROUP_CALENDAR_RECURRING_EVENTS", "PRODUCT_GROUP_FAVORITE", "PRODUCT_GROUP_MANITOBA_BOOKING", "PRODUCT_GROUP_OTHER_PATIENT_GENDER", "PRODUCT_GROUP_HIDE_LINES_WITH_END_DATE", "PRODUCT_GROUP_PATIENT_SYNC", "PRODUCT_GROUP_HOSPITAL_PHONE_REGISTRY_NOTICE", "PRODUCT_GROUP_HOSPITAL_PHONE_REGISTRY_STATUS", "PRODUCT_GROUP_HOSPITAL_PHONE_REGISTRY_ADD_MEMBERS", "PRODUCT_GROUP_HOSPITAL_REORDER_ASSIGNMENT", "PRODUCT_GROUP_HOSPITAL_EDIT_ACCOUNT", "PRODUCT_GROUP_SELF_REGISTER_CONFIRMED_PATIENT", "PRODUCT_GROUP_HOSPITAL_PHONE_REGISTRY_FAVORITE_NUM", "PRODUCT_GROUP_HOSPITAL_READ_ONLY_ACCESS", "PRODUCT_GROUP_HOSPITAL_MANAGE_DISPLAY_OPTIONS", "PRODUCT_GROUP_PATIENT_QUEUE_IT", "PRODUCT_GROUP_GENERIC_EMR", "PRODUCT_GROUP_HOURLY_AVAILABILITIES_SYNC", "PRODUCT_GROUP_PATIENT_MULTI_BOOKING", "PRODUCT_GROUP_SHOW_ONLY_HUB", "PRODUCT_GROUP_ACCESS_MANAGE_DOCUMENT", "PRODUCT_GROUP_WEBHOOKS_OMNIMED", "PRODUCT_GROUP_HUB_PATIENT_SECTION", "PRODUCT_GROUP_FIPA_LOGIN", "PRODUCT_GROUP_HOSPITAL_HISTORY_OF_CHANGES", "PRODUCT_GROUP_HOSPITAL_RESTORE_LAYOUT", "PRODUCT_GROUP_PATIENT_SHOW_AVAILABILITIES_TOGGLE", "PRODUCT_GROUP_SCHEDULING_FAST_PERIOD_DUPLICATION", "PRODUCT_GROUP_PATIENT_MASS_VIEW", "PRODUCT_ACCOUNT_GROUP_CALENDAR_IN_SCHEDULING", "PRODUCT_GROUP_HOSPITAL_PRINT_ADV_OPTIONS", "PRODUCT_GROUP_HOSPITALPOC_ADV_SEARCH", "PRODUCT_GROUP_SMS_AND_CALL_CONFIRMATION", "PRODUCT_GROUP_PATIENT_REDIRECTION", "PRODUCT_GROUP_HOSPITAL_EXPORT_MEMBERSHIP", "PRODUCT_GROUP_CLINIC_DETAILS", "PRODUCT_GROUP_HUB_DEACTIVATED_SERVICES_TAB", "PRODUCT_GROUP_HOSPITAL_MANAGE_SETTINGS", "PRODUCT_GROUP_BOOKING_EMAIL_CONFIRMATION", "PRODUCT_GROUP_BOOKING_REASON_OFFSET", "PRODUCT_GROUP_WEBHOOKS_PARTNER", "PRODUCT_GROUP_PROFILE_LICENSE_VALIDATION", "PRODUCT_GROUP_MEDESYNC_EMR", "PRODUCT_GROUP_WEBHOOKS_EMR", "PRODUCT_GROUP_HOSPITAL_ROLE_AND_PERMISSIONS", "PRODUCT_GROUP_HOSPITAL_CENTRE_COMMUNICATION", "PRODUCT_GROUP_DSQ_LICENSE_VALIDATION", "PRODUCT_GROUP_HUB_WIZARD_STAFF_IMPORT", "PRODUCT_GROUP_NEW_WS_BOOKING", "PRODUCT_GROUP_MEDFAR_EMR", "PRODUCT_GROUP_OFYS_EMR", "PRODUCT_GROUP_TOUBIB_EMR", "PRODUCT_GROUP_GENERIC_SOFTINFO_EMR", "PRODUCT_GROUP_HOSPITAL_EMERGENCY_PROCEDURES", "PRODUCT_GROUP_HOSPITAL_ORIGIN_OF_CALLS", "PRODUCT_GROUP_DELEGATE_DOCTOR", "PRODUCT_GROUP_GENERIC_KINLOGIX_EMR", "PRODUCT_GROUP_NOTIFY_PREFERRED_PARTNER", "PRODUCT_GROUP_RESOURCES_WORKERS", "PRODUCT_GROUP_REGIONS_SUB_REGIONS", "PRODUCT_GROUP_UPDATE_EMR_CONTACTS_METHOD", "PRODUCT_GROUP_CALENDAR_RECURRING_EVENTS_RELEASE2", "PRODUCT_GROUP_DISPATCH_SOURCES", "PRODUCT_GROUP_HUB_RESTRICT_INACTIVE_MEMBERSHIPS", "PRODUCT_GROUP_HOSPITAL_AFFILIATION", "PRODUCT_ACCOUNT_INACTIVITY_DEACTIVATION", "PRODUCT_GROUP_DISPATCH_SOURCES_CONFIGURATION", "PRODUCT_ACCOUNT_ICS_LOGS", "PRODUCT_GROUP_HUB_DEACTIVATION_RESOURCE", "PRODUCT_GROUP_PREFERRED_PARTNER_UPDATE", "PRODUCT_ACCOUNT_NEW_ICS_ATTRIBUTES", "PRODUCT_GROUP_PATIENT_SELF_SCHEDULING_PORTAL", "PRODUCT_GROUP_ASSOCIATED_PATIENT", "PRODUCT_GROUP_CCOM_BILLBOARD", "PRODUCT_GROUP_HUB_AUTOMATIC_RESOURCE_SYNC", "PRODUCT_GROUP_MYLE_PREF_PORTAL", "PRODUCT_GROUP_TAP_PREF_PORTAL", "PRODUCT_GROUP_HOSPITAL_AUTOMATIC_EXPORT", "PRODUCT_GROUP_ASSOCIATED_PATIENT_WORKAROUND", "PRODUCT_ACCOUNT_CALDAV_EXPORT", "PRODUCT_GROUP_AVAILABILITY_DUP_DELETION_WORKER", "PRODUCT_GROUP_PATIENT_SOURCE_TRUTH", "PRODUCT_GROUP_HUB_REF_NUM_MANAGEMENT", "PRODUCT_GROUP_SOFY_PREF_PORTAL", "PRODUCT_GROUP_OPEN_SHIFTS", "PRODUCT_GROUP_CCOM_CONTACT_GROUPS", "PRODUCT_GROUP_BI_REPORTS_APP", "PRODUCT_GROUP_PHYSICIAN_LEAD", "PRODUCT_GROUP_CLINIC_EMAIL", "PRODUCT_ACCOUNT_BI_REPORTS_APP", "PRODUCT_GROUP_CCOM_EMERGENCY_PROCEDURE_STEPS", "PRODUCT_GROUP_GENERIC_OMNIMED_EMR", "PRODUCT_GROUP_BI_REPORTS_APP_CSV_PER_QUARTER", "PRODUCT_GROUP_DAILY_HUB_REPORT_WORKERS", "PRODUCT_GROUP_RAMQ_GLB7_SERVICE", "PRODUCT_GROUP_THRESHOLD_MVP", "PRODUCT_GROUP_DISJOINT_AVAIL_SYNCS", "PRODUCT_GROUP_HUB_APPOINTMENTS_FOR_PARTNERS", "PRODUCT_GROUP_DISJOINT_APP_SYNCS", "PRODUCT_GROUP_WF_ASSIGNATIONS", "PRODUCT_GROUP_HUB_APPOINTMENTS_STATUS", "PRODUCT_GROUP_EMR_AVAIL_APT_DELETION", "PRODUCT_GROUP_HUB_REPORTS_DASHBOARD_ACCESS", "PRODUCT_GROUP_HUB_SERVICES_EXCLUDED_FROM_SYNC", "PRODUCT_GROUP_HOURLY_APPOINTMENTS_SYNC", "PRODUCT_GROUP_PATIENT_DAILY_AVAILABILITY_SYNC", "PRODUCT_GROUP_ISOLATED_MATH_TOOL" };

            var products = new List<Product>();
            foreach (var item in productCodes)
            {
                products.Add(new Product { Code = item });
            }
            DbContext.Principals.Add(new Domain.Entities.Principal()
            {
                KeyId = "a9b85d2e-6049-4558-9d36-447f3f7710b8",
                Secret = "51bcabef6ad7f9d117dabaf21969ab42446286a4fa30dc204bd4f27ff9f43f85",
                Name= "RVSQ",
                Products = products,
                Type = PrincipalType.Partner
            });

            DbContext.Principals.Add(new Domain.Entities.Principal()
            {
                KeyId = "a9b85d2e-6049-4558-9d36-447f3f7710b0",
                Secret = "51bcabef6ad7f9d117dabaf21969ab42446286a4fa30dc204bd4f27ff9f43f80",
                Name = "Bonjour-santé",
                Products = products,
                Type = PrincipalType.Partner
            });

            DbContext.Principals.Add(new Domain.Entities.Principal()
            {
                KeyId = "a9b85d2e-6049-4558-9d36-447f3f7710b1",
                Secret = "51bcabef6ad7f9d117dabaf21969ab42446286a4fa30dc204bd4f27ff9f43f81",
                Name = "Pomelo",
                Products = products,
                Type = PrincipalType.Partner
            });


            DbContext.SaveChanges();

            var principal = DbContext.Principals.First();
            if (principal is null)
            {
                throw new InvalidOperationException();
            }

            DbContext.ProductCodeUsages
                .Add(new Domain.Entities.Projections.ProductCodeUsageCount
                {
                    ProductCode = "PRODUCT_GROUP_HUB_APPOINTMENTS_FOR_PARTNERS",
                    Success = 999,
                    Failed = 123
                });
            DbContext.PrincipalAttemptedProducts
                .Add(new Domain.Entities.Projections.PrincipalAttemptedProduct
                {
                    Authorized = true,
                    AuthorizedAt = DateTime.Now,
                    PrincipalId = principal.Id,
                    ProductCode = "PRODUCT_GROUP_HUB_APPOINTMENTS_FOR_PARTNERS"
                });
            DbContext.SaveChanges();

        }
    }
}
