{{/*
Expand the name of the chart.
*/}}
{{- define "mello-api.name" -}}
{{- default .Chart.Name .Values.nameOverride | trunc 63 | trimSuffix "-" }}
{{- end }}

{{/*
Create a default fully qualified app name.
We truncate at 63 chars because some Kubernetes name fields are limited to this (by the DNS naming spec).
If release name contains chart name it will be used as a full name.
*/}}
{{- define "mello-api.fullname" -}}
{{- if .Values.fullnameOverride }}
{{- .Values.fullnameOverride | trunc 63 | trimSuffix "-" }}
{{- else }}
{{- $name := default .Chart.Name .Values.nameOverride }}
{{- if contains $name .Release.Name }}
{{- .Release.Name | trunc 63 | trimSuffix "-" }}
{{- else }}
{{- printf "%s-%s" .Release.Name $name | trunc 63 | trimSuffix "-" }}
{{- end }}
{{- end }}
{{- end }}

{{/*
Create chart name and version as used by the chart label.
*/}}
{{- define "mello-api.chart" -}}
{{- printf "%s-%s" .Chart.Name .Chart.Version | replace "+" "_" | trunc 63 | trimSuffix "-" }}
{{- end }}

{{/*
Common labels
*/}}
{{- define "mello-api.labels" -}}
helm.sh/chart: {{ include "mello-api.chart" . }}
{{ include "mello-api.selectorLabels" . }}
app: {{ include "mello-api.name" . }}
tag: {{ .Values.image.tag }}
{{- end }}

{{/*
Selector labels
*/}}
{{- define "mello-api.selectorLabels" -}}
app: {{ include "mello-api.name" . }}
tag: {{ .Values.image.tag }}
{{- end }}

{{/*
Create the name of the service account to use
*/}}
{{- define "mello-api.serviceAccountName" -}}
{{- if .Values.serviceAccount.create }}
{{- default (include "mello-api.fullname" .) .Values.serviceAccount.name }}
{{- else }}
{{- default "default" .Values.serviceAccount.name }}
{{- end }}
{{- end }}
