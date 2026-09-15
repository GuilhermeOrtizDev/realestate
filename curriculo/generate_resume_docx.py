#!/usr/bin/env python3
"""Gera currículo em .docx editável (Word / Google Docs)."""

from pathlib import Path

from docx import Document
from docx.enum.text import WD_ALIGN_PARAGRAPH
from docx.shared import Pt

OUTPUTS = [
    Path("/workspace/curriculo/Guilherme_Ortiz_Curriculo.docx"),
    Path("/opt/cursor/artifacts/Guilherme_Ortiz_Curriculo.docx"),
]


def set_run_font(run, size=10, bold=False):
    run.font.name = "Calibri"
    run.font.size = Pt(size)
    run.bold = bold


def add_heading(doc, text):
    p = doc.add_paragraph()
    p.alignment = WD_ALIGN_PARAGRAPH.LEFT
    run = p.add_run(text)
    set_run_font(run, size=11, bold=True)
    p.paragraph_format.space_before = Pt(10)
    p.paragraph_format.space_after = Pt(4)


def add_body(doc, text, justify=True):
    p = doc.add_paragraph()
    if justify:
        p.alignment = WD_ALIGN_PARAGRAPH.JUSTIFY
    run = p.add_run(text)
    set_run_font(run, size=10)
    p.paragraph_format.space_after = Pt(6)


def add_bullet(doc, text):
    p = doc.add_paragraph(style="List Bullet")
    run = p.add_run(text)
    set_run_font(run, size=10)
    p.paragraph_format.space_after = Pt(2)


def add_job(doc, title, period, subtitle=None):
    p = doc.add_paragraph()
    run = p.add_run(f"{title}  |  {period}")
    set_run_font(run, size=10, bold=True)
    p.paragraph_format.space_before = Pt(8)
    p.paragraph_format.space_after = Pt(2)
    if subtitle:
        p2 = doc.add_paragraph()
        r2 = p2.add_run(subtitle)
        set_run_font(r2, size=9)
        r2.italic = True
        p2.paragraph_format.space_after = Pt(4)


def build_doc():
    doc = Document()
    style = doc.styles["Normal"]
    style.font.name = "Calibri"
    style.font.size = Pt(10)

    # Nome
    p = doc.add_paragraph()
    p.alignment = WD_ALIGN_PARAGRAPH.CENTER
    r = p.add_run("GUILHERME ORTIZ")
    set_run_font(r, size=18, bold=True)

    p = doc.add_paragraph()
    p.alignment = WD_ALIGN_PARAGRAPH.CENTER
    r = p.add_run(
        "Especialista Full Cycle | .NET & Angular | Cloud & AI Integration"
    )
    set_run_font(r, size=10)

    p = doc.add_paragraph()
    p.alignment = WD_ALIGN_PARAGRAPH.CENTER
    r = p.add_run(
        "Ponta Grossa, PR | (42) 98886-0522 | guiortizsantos12@gmail.com\n"
        "LinkedIn: linkedin.com/in/dev-guilherme-ortiz"
    )
    set_run_font(r, size=9)

    add_heading(doc, "SOBRE")
    add_body(
        doc,
        "Desenvolvedor Sênior Full Cycle (.NET, Angular, AWS), com foco em "
        "arquitetura de microsserviços, cloud e qualidade de software. "
        "Participo da definição técnica e da construção end-to-end — da API "
        "à infraestrutura — com autonomia no ciclo de vida do produto.",
    )

    add_heading(doc, "EXPERIÊNCIA PROFISSIONAL")

    add_job(doc, "Desenvolvedor Sênior — SmartTravel", "Jul 2024 – Atual")
    for t in [
        "Participei da migração da infraestrutura para AWS em 3 meses, saindo de Windows para Linux e reduzindo dependência de ambiente legado.",
        "Refatorei o sistema de síncrono para assíncrono para viabilizar a operação em Linux e melhorar resiliência sob carga.",
        "Desenvolvi o motor Conexão para matching de rotas multi-trecho em tempo real (ex.: CWB→SP→Rio) com grafos e DocumentDB, alimentado por worker Kafka.",
        "Conduzi o ciclo com IA (Prompt Engineering, LLM, Semantic Kernel, RAG): análise da base SQL Server de referência, documentação via MCP no Confluence, especificação em Markdown, TDD e geração de código; MCP integrado a AWS, Grafana e GitHub para observabilidade e workflows.",
        "Atuei na arquitetura e evolução de microsserviços críticos de logística, vendas e financeiro.",
    ]:
        add_bullet(doc, t)

    add_job(
        doc,
        "Especialista Full Cycle — Cyber Software",
        "Fev 2023 – Ago 2024",
        "Empresa própria — projetos sob encomenda / PJ",
    )
    for t in [
        "Concepção e implementação completa da arquitetura de plataforma imobiliária multi-tenant (APIs .NET + UI), com isolamento por cliente.",
        "Entreguei o Te-A App (iOS e Android) em 3 meses, com pagamentos, assinaturas e publicação nas lojas Apple e Google.",
        "Montei DevOps completo na AWS (EC2, RDS, S3, Load Balancer, ElastiCache) com observabilidade, suportando pagamentos e ciclo de assinatura em produção.",
    ]:
        add_bullet(doc, t)

    add_job(doc, "Desenvolvedor Pleno — Wake Commerce", "Jul 2023 – Jun 2024")
    for t in [
        "Desenvolvi o Storefront como centralizador de APIs, substituindo chamadas dispersas a múltiplos serviços por um único ponto de acesso e melhorando performance e velocidade das consultas.",
        "Implementei comunicação GraphQL e geração dinâmica de código frontend com Escriban, acelerando entregas de telas e contratos tipados.",
    ]:
        add_bullet(doc, t)

    add_job(doc, "Desenvolvedor Pleno — Meta", "Jun 2022 – Jun 2023")
    for t in [
        "Atuei na otimização de microsserviços de análise de crédito e scoring de risco, melhorando tempo de resposta e estabilidade sob volume de consultas.",
        "Participei do desenvolvimento Full Stack em fase crítica de projeto de logística de transporte, entregando funcionalidades no caminho crítico do go-live.",
    ]:
        add_bullet(doc, t)

    add_job(
        doc,
        "Desenvolvedor Júnior — Scheffer Logística e Automação",
        "Jan 2021 – Mai 2022",
    )
    for t in [
        "Efetivado após 3 meses de estágio pela performance na vaga aberta — primeira posição CLT.",
        "Com 6 meses de casa, propus e coordenei a migração de sistemas Windows Forms para Web (ASP.NET MVC Core); em 1 ano desenhei a arquitetura e conduzi a evolução do legado.",
        "Desenvolvi soluções WCS/WMS para automação logística industrial.",
    ]:
        add_bullet(doc, t)

    add_heading(doc, "FORMAÇÃO")
    add_body(doc, "Bacharelado em Ciência da Computação — UTFPR | 2023", justify=False)

    add_heading(doc, "SKILLS")
    for line in [
        "Backend & IA: .NET 8, EF Core, Microservices, Prompt Engineering, LLM, RAG, Semantic Kernel",
        "Frontend: Angular, TypeScript, Razor, Bootstrap",
        "Cloud & Infra: AWS (EC2, S3, RDS, Load Balancer, ElastiCache), DigitalOcean, Docker, Kubernetes, CI/CD",
        "Data & Observability: SQL Server, PostgreSQL, DocumentDB, Grafana, CloudWatch, Prometheus",
        "Messaging & APIs: RabbitMQ, Kafka, Hangfire, GraphQL, RESTful",
        "Ferramentas: MCP (Confluence, AWS, Grafana, GitHub), Cursor",
    ]:
        add_bullet(doc, line)

    return doc


def main():
    doc = build_doc()
    for out in OUTPUTS:
        out.parent.mkdir(parents=True, exist_ok=True)
        doc.save(str(out))
        print(f"Wrote {out} ({out.stat().st_size} bytes)")


if __name__ == "__main__":
    main()
